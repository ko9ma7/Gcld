using Liuliu.ScriptEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liuliu.ScriptEngine.Damo;
using Liuliu.ScriptEngine;
using System.Diagnostics;
using System.Threading;
using Liuliu.ScriptEngine.Tasks;

namespace Liuliu.MouseClicker
{
    public class Role : IRole
    {
        /// <summary>
        /// 创建一个角色
        /// </summary>
        /// <param name="hwnd">角色所在窗口句柄</param>
        public Role(int hwnd)
        {
            _window = new DmWindow(new DmPlugin(), hwnd);
            _dm = _window.Dm;
            Debug.WriteLine(_window.Dm.Ver());
        }
        private DmWindow _window;
        private DmPlugin _dm;
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
                return "";
            }
        }

        public Action<string> OutMessage
        {
            get
            {
                return (str) => { Debug.WriteLine("[" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + "角色通知："+str); };
            }
        }

        public Action<string> OutSubMessage
        {
            get
            {
                return (str) => { Debug.WriteLine("[" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + "角色通知："+str); };
            }
        }

        public DmWindow Window
        {
            get
            {
                return _window;
            }
        }


         public bool OpenTeshushijian()
        {
            OutSubMessage("打开特殊事件...");
            //int intX, intY;
            //_dm.FindMultiColor(258, 34, 854, 218, "d69f5a", "-8|5|3a3327,5|13|d5c484,21|14|cfbf80,29|6|2f2a1e,-10|1|352d20,-5|-2|c89b60,2|22|1f0201", 0.9, 0, out intX, out intY);

            if (_dm.FindPicAndClick(258, 34, 854, 218,@"\bmp\特殊事件.bmp",37,23))
            {
                _dm.Delay(1000);
                OutSubMessage("打开成功!");
                return true;
            }
            OutSubMessage("打开失败!");
            return false;
        }
        public bool OpenHuodong()
        {
            int intX, intY;
            _dm.FindStr(258, 34, 854, 218, "活动", "C09755-27413C", 0.9, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                _dm.MoveToClick(intX, intY);
                _dm.Delay(1000);
                return true;
            }
            return false;
        }

        public bool ChangeRole()
        {
            _dm.MoveToClick(29, 34);
            _dm.Delay(1000);
      
                _dm.Delay(1000);

                Delegater.WaitTrue(()=>
                {
                    OpenWindowMenu("角色");
                    return _dm.FindPicAndClick(446, 408, 580, 486, @"\bmp\切换角色.bmp");
                
                },()=>_dm.Delay(1000));

                _dm.Delay(1000);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(1000);
                 
                _dm.FindPicAndClick(316, 289, 635, 482, @"\bmp\等级.bmp");
                _dm.Delay(500);
                _dm.FindPicAndClick(316, 289, 635, 482, @"\bmp\开始.bmp");

                CloseWindow();
    
            return true;
        }

        public bool OpenRemind()
        {
            OutSubMessage("打开提醒...");
            if (_dm.FindPicAndClick(283, 33, 906, 301,@"\bmp\提醒.bmp"))
            {
                _dm.Delay(1000);
                OutSubMessage("打开成功!");
                return true;
            }
            OutSubMessage("打开失败!");
            return false;
        }

        public bool CloseWindow()
        {
            OutSubMessage("开始关闭窗口...");
            int intX, intY;
            _dm.FindMultiColor(539, 0, 916, 298, "f4c792","-11|4|be1a1c,-6|-7|fbd7c5,6|8|d9af79,-7|8|d6ab77,0|14|aa0305,-14|1|aa0305,13|-1|ac0507,1|-12|bb1719", 0.9, 0, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                _dm.MoveToClick(intX, intY);
                _dm.Delay(1000);
                OutSubMessage("关闭窗口成功!");
                return true;
            }
            OutSubMessage("关闭窗口失败!");
            return false;
        }

        public bool OpenWindowMenu(string menu)
        {
           
            OutSubMessage("开始打开窗口...");
            //未选中:45.34.60-5.5.20
            //选中:60.18.75-5.5.25
            if (_dm.FindStrAndClick(80,3,934,78,menu,"45.34.60-5.5.20|60.18.75-5.5.25"))
            {
                _dm.Delay(1000);
                OutSubMessage("打开窗口["+menu+"]成功!");
                return true;
            }
            OutSubMessage("打开窗口[" + menu + "]失败!");
            return false;

        }

        public bool OpenMap()
        {
            int intX, intY;
            while (true)
            {
               
                _dm.MoveToClick(920, 69);
                _dm.Delay(1000);
                _dm.FindStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25", 0.9, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    return true;
                }
            } 
        

        }
        public bool CloseMap()
        {
            int intX, intY;
            while (true)
            {
                _dm.FindStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25", 0.9, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    _dm.MoveToClick(920, 69);
                    _dm.Delay(1000);
                }
                else
                    return true;

            }
        }
        

    }
}
