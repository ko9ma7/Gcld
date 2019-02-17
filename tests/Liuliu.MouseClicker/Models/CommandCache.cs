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
    public class CommandCache
    {
        public CommandCache()
        {
            
        }
        public string Token;
        public List<string> SendDataCache = new List<string>();
        public List<string> ReceiveDataCache = new List<string>();


        public void UpdateData(string command,string data)
        {
            if (SoftContext.CommandList.ContainsKey(key + msgPro.MessageCommand))
            {
                SoftContext.CommandList[key + msgPro.MessageCommand] = rootObj;
            }
            else
            {
                SoftContext.CommandList.Add(key + msgPro.MessageCommand, rootObj);
            }
        }
         
    }
}
