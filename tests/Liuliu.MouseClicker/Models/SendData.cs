using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    public class SendData<T>
    {
        public SendData(string message,T data)
        {
            Message = message;
            Data = data;
        }
        public SendData()
        {

        }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class SendData
    {
        public SendData(string message)
        {
            Message = message;
            Data = null;
        }
        public SendData(string message, object data)
        {
            Message = message;
            Data = data;
        }
        public SendData()
        {

        }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
