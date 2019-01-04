using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    public class RequestModel
    {
        public string Command { get; set; }
        public int Token { get; set; }
        public bool Modal { get; set; }
        public bool IsRequest { get; set; }
        public bool IsMatch { get; set; }

        public RequestModel(string command = "", bool modal = true, bool isMatch = false)
        {
            this.Command = command;
            this.Modal = modal;
            this.IsMatch = isMatch;
        }
    }
}