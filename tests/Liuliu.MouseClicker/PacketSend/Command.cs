using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.PacketSend
{
    public class Command
    {
        public CmdType CommandType { get; set; }
        /// <summary>
        /// 包序
        /// </summary>
        public static int token { get; set; }
        /// <summary>
        /// 命令
        /// </summary>
        public string command { get; set; }

        public string commandstr { get; set; }
        /// <summary>
        /// 报文长度
        /// </summary>
        public int dataLength { get; set; }

        public byte[] outputarr { get; set; }

        public Dictionary<string, string> sendlst;

        static Command()
        {
            token = 0;
        }

        public Command(string cmd, Dictionary<string, string> lst)
        {
            CommandType = CommandList.getCurCmdType(cmd);

            token++;

            command = cmd;
            sendlst = lst;

            string str = string.Empty;
            if (lst != null)
            {
                foreach (var item in lst)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str + "&";
                    }
                    str += item.Key + "=" + item.Value;
                }
            }

            int nDataLength = 4/*包头，标识长度*/+ 32/*命令*/+ 4/*包序*/+ str.Length;
            outputarr = new byte[nDataLength];

            int m = nDataLength - 4;
            byte[] bLen = new byte[4];
            bLen[3] = (byte)(m & 0xFF);
            bLen[2] = (byte)((m & 0xFF00) >> 8);
            bLen[1] = (byte)((m & 0xFF0000) >> 16);
            bLen[0] = (byte)((m >> 24) & 0xFF);

            System.Text.Encoding encoder = Encoding.UTF8;
            byte[] bCmd = encoder.GetBytes(cmd);
            byte[] bToken = new byte[4]; // BitConverter.GetBytes(token);
            bToken[3] = (byte)(token & 0xFF);
            bToken[2] = (byte)((token & 0xFF00) >> 8);
            bToken[1] = (byte)((token & 0xFF0000) >> 16);
            bToken[0] = (byte)((token >> 24) & 0xff);
            byte[] bLst = encoder.GetBytes(str);

            Array.Copy(bLen, outputarr, 4);
            Array.Copy(bCmd, 0, outputarr, 4, bCmd.Length);
            Array.Copy(bToken, 0, outputarr, 36, 4);// outputarr.SetValue(token, 36);
            Array.Copy(bLst, 0, outputarr, 40, bLst.Length);

        }

        public Command(byte[] arr)
        {
            outputarr = arr;
            int nLen = (int)(arr[0] << 24) + (int)(arr[1] << 16) + (int)(arr[2] << 8) + (int)(arr[3]);

            dataLength = nLen;

            byte[] bcmd = new byte[32];
            Array.Copy(arr, 4, bcmd, 0, 32);
            string cmdstr = System.Text.Encoding.Default.GetString(bcmd).TrimEnd('\0');
            command = cmdstr;

            int cmdstrLen = dataLength - (/*  4+包头，标识长度 不包括包头部分*/32/*命令*/+ 4/*包序*/);
            if (cmdstrLen == 0)
            {
                commandstr = "";
                return;
            }
            else if (cmdstrLen < 0)
            {
                commandstr = "未知异常";
                return;
            }
            try
            {
                byte[] bcmdstr = new byte[cmdstrLen];
                Array.Copy(arr, 40, bcmdstr, 0, cmdstrLen);
                commandstr = System.Text.Encoding.Default.GetString(bcmdstr).TrimEnd('\0');
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
        }

        public Command(string cmd, string cmdstr)
        {

            token++;

            command = cmd;
            // sendlst = lst;

            //string str = string.Empty;
            //if (lst != null)
            //{
            //    foreach (var item in lst)
            //    {
            //        if (!string.IsNullOrEmpty(str))
            //        {
            //            str = str + "&";
            //        }
            //        str += item.Key + "=" + item.Value;
            //    }
            //}
            System.Text.Encoding encoder = Encoding.UTF8;
            byte[] bLst = encoder.GetBytes(cmdstr);

            int nDataLength = 4/*包头，标识长度*/+ 32/*命令*/+ 4/*包序*/+ bLst.Length;
            outputarr = new byte[nDataLength];

            int m = nDataLength - 4;
            byte[] bLen = new byte[4];
            bLen[3] = (byte)(m & 0xFF);
            bLen[2] = (byte)((m & 0xFF00) >> 8);
            bLen[1] = (byte)((m & 0xFF0000) >> 16);
            bLen[0] = (byte)((m >> 24) & 0xFF);


            byte[] bCmd = encoder.GetBytes(cmd);
            byte[] bToken = new byte[4]; // BitConverter.GetBytes(token);
            bToken[3] = (byte)(token & 0xFF);
            bToken[2] = (byte)((token & 0xFF00) >> 8);
            bToken[1] = (byte)((token & 0xFF0000) >> 16);
            bToken[0] = (byte)((token >> 24) & 0xff);


            Array.Copy(bLen, outputarr, 4);
            Array.Copy(bCmd, 0, outputarr, 4, bCmd.Length);
            Array.Copy(bToken, 0, outputarr, 36, 4);// outputarr.SetValue(token, 36);
            Array.Copy(bLst, 0, outputarr, 40, bLst.Length);
        }
        //private static int m_heattoken = 1;
        //public Command(string cmd)
        //{
        //    if (cmd == CommandList.HEART_BEAT_TEST2)
        //    {

        //    }
        //}
    }
}
