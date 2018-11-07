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
using Liuliu.MouseClicker.Mvvm;
using System.Windows.Controls;

namespace Liuliu.MouseClicker
{
    public class Role : ViewModelExBase,IRole
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
            _hwnd = hwnd;
            TaskEngine = new TaskEngine();
            TaskEngine.OutMessage = OutMessage;
            TaskEngine.Window = _window;
            WindowTitle = _window.TopTitle;
            ProcessId = _window.ProcessId;
        }
        private DmWindow _window;
        private DmPlugin _dm;
        private string _windowTitle;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                SetProperty(ref _windowTitle, value, () => WindowTitle);
            }
        }


        private int _hwnd;
        public int Hwnd
        {
            get { return _hwnd; }
            set
            {
                SetProperty(ref _hwnd, value, () => Hwnd);
            }
        }
        private int _processId;
        public int ProcessId
        {
            get { return _processId; }
            set
            {
                SetProperty(ref _processId, value, () => ProcessId);
            }
        }
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

        
       private ComboBoxItem _selectedItemTask;
        public ComboBoxItem SelectedItemTask
        {
            get { return _selectedItemTask; }
            set
            {
                SetProperty(ref _selectedItemTask, value, () => SelectedItemTask);
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, () => Name);
            }
        }

        public TaskEngine TaskEngine { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value, () => Message);
            }
        }
        private string _subMessage;
        public string SubMessage
        {
            get { return _subMessage; }
            set
            {
                SetProperty(ref _subMessage, value, () => SubMessage);
            }
        }
        public Action<string> OutMessage
        {
            get
            {
                return (str) => { Message = str; };
            }

        }

        public Action<string> OutSubMessage
        {
            get
            {
                return (str) => { SubMessage = str; };
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

            if (_dm.FindPicAndClick(258, 34, 854, 218,@"\bmp\特殊事件.bmp|\bmp\特殊事件2.bmp",37,23))
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
            OutMessage("切换角色中...");
            Delegater.WaitTrue(() => _dm.MoveToClick(29, 34),()=>IsExistWindowMenu("角色"),() => _dm.Delay(1000));
                Delegater.WaitTrue(()=>
                {
                    OpenWindowMenu("角色");
                    return _dm.FindPicAndClick(446, 408, 580, 486, @"\bmp\切换角色.bmp|\bmp\切换角色2.bmp");
                
                },()=>_dm.IsExistPic(394, 416, 563, 486, @"\bmp\开始游戏.bmp|\bmp\开始游戏2.bmp"),()=>_dm.Delay(1000));
                
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
            return Delegater.WaitTrue(() =>
             {
                 _dm.FindMultiColor(539, 0, 916, 298, "f4c792", "-11|4|be1a1c,-6|-7|fbd7c5,6|8|d9af79,-7|8|d6ab77,0|14|aa0305,-14|1|aa0305,13|-1|ac0507,1|-12|bb1719", 0.9, 0, out intX, out intY);
                 if (intX > 0 && intY > 0)
                 {
                     _dm.MoveToClick(intX, intY);
                     _dm.Delay(1000);
                     _dm.FindMultiColor(539, 0, 916, 298, "f4c792", "-11|4|be1a1c,-6|-7|fbd7c5,6|8|d9af79,-7|8|d6ab77,0|14|aa0305,-14|1|aa0305,13|-1|ac0507,1|-12|bb1719", 0.9, 0, out intX, out intY);
                     if (intX > 0 && intY > 0)
                     {
                         OutSubMessage("关闭窗口失败!");
                         return false;
                     }
                     OutSubMessage("关闭窗口成功!");
                     return true;
                 }
                 OutSubMessage("关闭窗口成功!");
                 return true;
             }, () => _dm.Delay(1000),5);
          
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
        /// <summary>
        /// 是否存在面板标题(商店,仓库,回购等)
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool IsExistWindowMenu(string menu)
        {

            // OutSubMessage("开始打开窗口...");
            //未选中:45.34.60-5.5.20
            //选中:60.18.75-5.5.25
            return _dm.IsExistStr(80, 3, 934, 78, menu, "45.34.60-5.5.20|60.18.75-5.5.25");
        }
        public bool OpenMap()
        {
          return Delegater.WaitTrue(() => _dm.MoveToClick(920, 69),
                               () => _dm.IsExistStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25"),
                               ()=>_dm.Delay(1000),2000);
        }
        public bool CloseMap()
        {
            return Delegater.WaitTrue(() => _dm.MoveToClick(920, 69),
                                 () => !_dm.IsExistStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25"),
                                 () => _dm.Delay(1000),2000);
        }
        

        public bool OpenActivityBoard(string activity)
        {
            if (_dm.IsExistStr(75, 2, 909, 70, activity, "45.34.60-5.5.20|60.18.75-5.5.25"))
            {
                OutSubMessage("活动面板["+activity+"]已经打开!");
                return Delegater.WaitTrue(() => {
                    _dm.FindStrAndClick(75, 2, 909, 70, activity, "45.34.60-5.5.20");
                    _dm.Delay(500);
                    if (_dm.IsExistStr(75, 2, 909, 70, activity, "60.18.75-5.5.25"))
                        return true;
                    return false;
                }, () => _dm.Delay(500), 10);
            }
            else
                CloseWindow();

            string points=_dm.FindPicEx(286, 37, 875, 284, @"\bmp\活动2.bmp", "202020", 0.8, 0);
            Debug.WriteLine(points);

            if (points == "")
            {
                CloseWindow();
                return false;
            }
            string[] t= points.Split('|');

            foreach (var item in t)
            {
                string[] p = item.Split(',');
                _dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                _dm.Delay(1000);
                if (_dm.IsExistStr(75, 2, 909, 70, activity, "45.34.60-5.5.20|60.18.75-5.5.25"))
                {
                    return Delegater.WaitTrue(() => {
                         _dm.FindStrAndClick(75, 2, 909, 70, activity, "45.34.60-5.5.20");
                         _dm.Delay(500);
                         if (_dm.IsExistStr(75, 2, 909, 70, activity, "60.18.75-5.5.25"))
                            return true;
                        return false;
                        },() => _dm.Delay(500), 10);
                }
                else
                    CloseWindow();
            
            }
            CloseWindow();
            return false;
        }
        /// <summary>
        /// 打开菜单栏(装备,资源,武将,国家等)
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool OpenMenu(string menu)
        {
            return _dm.FindPicAndClick(331, 467, 869, 537, menu);
        }


        public bool GoToMap(string map)
        {
            switch(map)
            {
                case "世界":
                   if(_dm.IsExistPic(818, 281, 953, 447,@"\bmp\主城.bmp")&&_dm.IsExistPic(818, 281, 953, 447,@"\bmp\副本.bmp"))
                    {
                        OutSubMessage("已经在世界界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\世界.bmp"),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"),
                               () => _dm.Delay(1000));
                    break;
                case "副本":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"))
                    {
                        OutSubMessage("已经在副本界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\副本.bmp"),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"),
                               () => _dm.Delay(1000));
                    break;
                case "主城":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                    {
                        OutSubMessage("已经在主城界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\主城.bmp"),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"),
                               () => _dm.Delay(1000));
                    break;
                default:
                    OutSubMessage("输入地图错误,无法打开");
                    break;
            }
            _dm.Delay(2000);
            return true;
        }


    }

    enum  当前位置
    {
        World,
        MainCity,
        InstanceZones,
        Unknown
    }
    enum Activity
    {
      天降神剑,
  武将犒赏,
                    古城探宝,
                    讨伐董卓,
                    青梅煮酒,
                    大宴群雄,
                    矿山开采,
                    神锤宝石,
                    攻城宝箱,
                    陨铁放送,
                    七擒孟获,
                    万邦来朝,
                    宝石矿脉,
                    以酒论友,
                    海岛寻宝,
                    宝石转盘,
                  长版突围,
                    天灯许愿,
                    广结名士,
                  神锤陨铁,
                   草船借箭,
                    杏花酒宴,
                   丝绸酬宾,
                    钢铁酬宾,
                   铁甲冲锋,
                    镇守襄阳,

    }
}
