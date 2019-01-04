using Liuliu.MouseClicker.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    /// <summary>
    /// 【消息协议】=【消息长度4字节】+【命令32字节】+【token4字节】+【实际消息内容】+【多于消息内容】
    /// 消息长度=命令+token+消息内容
    /// </summary>
    public class MsgProtocol
    {
        #region 实际消息长度
        private int _messageLength;
        /// <summary>
        /// 实际消息长度,不包含长度4字节
        /// </summary>
        public int MessageLength
        {
            get { return _messageLength; }
            set { _messageLength = value; }
        }
        #endregion
        #region 实际消息内容
        private byte[] _messageContent = new byte[] { };
        /// <summary>
        /// 实际消息内容
        /// </summary>
        public byte[] MessageContent
        {
            get { return _messageContent; }
            set { _messageContent = value; }
        }
        #endregion

        #region 消息命令
        private string _messageCommand;
        /// <summary>
        /// 消息命令
        /// </summary>
        public string MessageCommand
        {
            get { return _messageCommand; }
            set { _messageCommand = value; }
        }
        #endregion
        #region 消息令牌
        private int _messageToken;
        /// <summary>
        /// 消息令牌
        /// </summary>
        public int MessageToken
        {
            get { return _messageToken; }
            set { _messageToken = value; }
        }
        #endregion
        #region 消息数据
        private string _jsonData;
        /// <summary>
        /// JSON数据
        /// </summary>
        public string JsonData
        {
            get { return _jsonData; }
            set { _jsonData = value; }
        }
        #endregion

        #region 多余的Bytes
        private byte[] _extraBytes = new byte[] { };
        /// <summary>
        /// 多余的Bytes
        /// </summary>
        public byte[] ExtraBytes
        {
            get { return _extraBytes; }
            set { _extraBytes = value; }
        }

        #endregion

        #region 构造函数两个
        public MsgProtocol()
        {
            //
        }
        #endregion

        #region MsgProtocol 转换为 byte[]
        /// <summary>
        /// MsgProtocol 转换为 byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] _bytes; //自定义字节数组，用以装载消息协议

            using (MemoryStream memoryStream = new MemoryStream()) //创建内存流
            {
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream); //以二进制写入器往这个流里写内容

                binaryWriter.Write(BitConverter.GetBytes(_messageLength).Reverse().ToArray()); //写入实际消息长度，占4个字节  
                if (_messageLength > 0)
                {
                    binaryWriter.Write(_messageContent); //写入实际消息内容
                }

                _bytes = memoryStream.ToArray(); //将流内容写入自定义字节数组

                binaryWriter.Close(); //关闭写入器释放资源
            }

            return _bytes; //返回填充好消息协议对象的自定义字节数组
        }
        #endregion

        #region byte[] 转换为 MsgProtocol
        /// <summary>
        /// byte[] 转换为 MsgProtocol
        /// </summary>
        /// <param name="buffer">字节数组缓冲器。</param>
        /// <returns></returns>
        public static MsgProtocol FromBytes(byte[] buffer)
        {
            int bufferLength = buffer.Length;

            MsgProtocol msgProtocol = new MsgProtocol();

            using (MemoryStream memoryStream = new MemoryStream(buffer)) //将字节数组填充至内存流
            {
                BinaryReader binaryReader = new BinaryReader(memoryStream); //以二进制读取器读取该流内容
                msgProtocol.MessageLength = BitConverter.ToInt32(binaryReader.ReadBytes(4).Reverse().ToArray(), 0); //读取数据长度，4字节          
                //如果进来的Bytes长度大于一个完整的MsgProtocol长度
                if (msgProtocol.MessageLength < 0)
                    return null;
                if ((bufferLength - 4) > msgProtocol.MessageLength)
                {
                    msgProtocol.MessageContent = binaryReader.ReadBytes(msgProtocol.MessageLength); //读取实际消息内容，从第5个字节开始读
                    msgProtocol.ExtraBytes = binaryReader.ReadBytes(bufferLength - 4 - msgProtocol.MessageLength); //余下的数据
                }

                //如果进来的Bytes长度等于一个完整的MessageXieYi长度
                if ((bufferLength - 4) == msgProtocol.MessageLength)
                {
                    msgProtocol.MessageContent = binaryReader.ReadBytes(msgProtocol.MessageLength); //读取实际消息内容，从第5个字节开始读
                }
                if((bufferLength-4)>=msgProtocol.MessageLength)
                {
                    byte[] commandBytes = new byte[32];
                    byte[] tokenBytes = new byte[4];
                    byte[] dataBytes = new byte[msgProtocol.MessageContent.Length - 4 - 32];
                    Array.Copy(msgProtocol.MessageContent, 0, commandBytes, 0, 32); //命令32字节
                    Array.Copy(msgProtocol.MessageContent, 32, tokenBytes, 0,4); //token4字节
                    Array.Copy(msgProtocol.MessageContent, 32 + 4, dataBytes, 0, dataBytes.Length); //数据
                    msgProtocol.MessageCommand = Encoding.UTF8.GetString(commandBytes).Replace("\0", "");
                    msgProtocol.MessageToken = BitConverter.ToInt32(tokenBytes.Reverse().ToArray(), 0);
                    msgProtocol.JsonData = Encoding.UTF8.GetString(Zip.DeCompress(dataBytes));
                   
                }
                binaryReader.Close(); //关闭二进制读取器，释放资源
            }
            return msgProtocol; //返回消息协议对象
        }
        #endregion

    }
}
