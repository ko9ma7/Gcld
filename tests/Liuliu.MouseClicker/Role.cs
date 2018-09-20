using Liuliu.ScriptEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liuliu.ScriptEngine.Damo;
using Liuliu.ScriptEngine;
using System.Diagnostics;

namespace Liuliu.MouseClicker
{
    public class Role : IRole
    {
        public Role()
        {
            _window = new DmWindow(new DmPlugin(), 68276);
            Debug.WriteLine(_window.Dm.Ver());
        }
        private DmWindow _window;

        public string Ac
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Area
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CurrentMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Empirical
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int EmpiricalMax
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Level
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Action<string> OutMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Action<string> OutSubMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DmWindow Window
        {
            get
            {
                return _window;
            }
        }
    }
}
