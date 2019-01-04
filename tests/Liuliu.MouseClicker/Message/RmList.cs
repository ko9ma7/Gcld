using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    public class RmList
    {
        public RequestModel RequestModel { get; set; }
        public int Token { get; set; }
        public Action CallBack { get; set; }
        public bool IsAlertError { get; set; }
        public DateTime Time { get; set; }
        public object SendData { get; set; }
        public Tuple<int,int> MousePoint { get; set; }
    }
}
