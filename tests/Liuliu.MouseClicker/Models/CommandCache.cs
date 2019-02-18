using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    public enum DataType
    {
        通知类,
        更新类
    }
    public enum PacketType
    {
        Send,
        Receive
    }
    public class CommandCache
    {
        public CommandCache()
        {
            
        }
        public string ClientIpAndPort { get; set; }
        private Dictionary<string, string> SendDataCache = new Dictionary<string, string>();
        private Dictionary<string, string> ReceiveDataCache = new Dictionary<string, string>();
        /// <summary>
        /// 更新缓存数据
        /// </summary>
        /// <param name="type">封包是发送还是接收</param>
        /// <param name="command">封包命令</param>
        /// <param name="jsonData">封包数据</param>
        public void UpdateData(PacketType type,string command,string jsonData)
        {
            if (type==PacketType.Send&&command == "player@getPlayerInfo")
            {
                this.ReceiveDataCache.Clear();
                this.SendDataCache.Clear();
                System.Diagnostics.Debug.WriteLine("切换角色，清除数据!");
            }
           
            switch (type)
            {
                case PacketType.Receive:
                    if (ReceiveDataCache.ContainsKey(command))
                        ReceiveDataCache[command] = jsonData;
                    else
                        ReceiveDataCache.Add(command, jsonData);
                    break;
                case PacketType.Send:
                    if (SendDataCache.ContainsKey(command))
                        SendDataCache[command] = jsonData;
                    else
                        SendDataCache.Add(command, jsonData);
                    break;
                default:
                    break;
            }
            
        }
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="type">封包是发送还是接收</param>
        /// <param name="command">封包命令</param>
        /// <returns>封包数据</returns>
        public string GetData(PacketType type,string command)
        {
            switch (type)
            {
                case PacketType.Receive:
                    if (ReceiveDataCache.ContainsKey(command))
                        return ReceiveDataCache[command];
                    break;
                case PacketType.Send:
                    if (SendDataCache.ContainsKey(command))
                        return SendDataCache[command];
                    break;
                default:
                    break;
            }
            return "";
        }
         
    }
}
