﻿using Liuliu.ScriptEngine.Models;
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
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Contexts;
using Newtonsoft.Json.Linq;
using Liuliu.MouseClicker.Models.Entities;

namespace Liuliu.MouseClicker
{
    public class Role : ViewModelExBase, IRole
    {
        /// <summary>
        /// 创建一个角色
        /// </summary>
        /// <param name="hwnd">角色所在窗口句柄</param>
        public Role(int hwnd, int noxVMHandlePid)
        {
            _window = new DmWindow(new DmPlugin(), hwnd);
            _dm = _window.Dm;
            Debug.WriteLine(_window.Dm.Ver());
            _hwnd = hwnd;
            TaskEngine = new TaskEngine();
            TaskEngine.OutMessage = OutMessage;
            TaskEngine.Window = _window;
            WindowTitle = _window.TopTitle;
            _noxVMHandlePid = noxVMHandlePid;
            GameHelper = new GameHelper(_noxVMHandlePid);
            套装 青龙套装 = new 套装() { 套装名称 = new 套装名称() { Name = "青龙" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.血量 } };
            套装 白虎套装 = new 套装() { 套装名称 = new 套装名称() { Name = "白虎" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 朱雀套装 = new 套装() { 套装名称 = new 套装名称() { Name = "朱雀" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强壮 } };
            套装 鲮鲤套装 = new 套装() { 套装名称 = new 套装名称() { Name = "鲮鲤" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强防 } };
            套装 玄武套装 = new 套装() { 套装名称 = new 套装名称() { Name = "玄武" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.防御 } };
            套装 霸下套装 = new 套装() { 套装名称 = new 套装名称() { Name = "霸下" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.掌控 } };
            套装 驱虎套装 = new 套装() { 套装名称 = new 套装名称() { Name = "驱虎" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 烛龙套装 = new 套装() { 套装名称 = new 套装名称() { Name = "烛龙" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强防 } };
            套装 凤凰套装 = new 套装() { 套装名称 = new 套装名称() { Name = "凤凰" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 灵龟套装 = new 套装() { 套装名称 = new 套装名称() { Name = "灵龟" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.掌控 } };
            TaozhuangList = new List<套装>() { 青龙套装, 白虎套装, 朱雀套装, 鲮鲤套装, 玄武套装, 霸下套装, 驱虎套装, 烛龙套装, 凤凰套装, 灵龟套装 };
            _player = GameHelper.GetPlayer();
            IsSkipIfOne = true;
        }
        public int Id { get; set; }
        private int _noxVMHandlePid;
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

        public WeaponInfo GetWeaponInfo()
        {
            return GameHelper.GetWeaponInfo();
        }

        private Player _player;
        public Player Player
        {
            get { return _player; }
            set
            {
                SetProperty(ref _player, value, () => Player);
            }
        }
        private bool _isAutoLogin;
        public bool IsAutoLogin
        {
            get { return _isAutoLogin; }
            set
            { SetProperty(ref _isAutoLogin, value, () => IsAutoLogin); }
        }

        private bool _isChangeRole;
        public bool IsChangeRole
        {
            get { return _isChangeRole; }
            set
            { SetProperty(ref _isChangeRole, value, () => IsChangeRole); }
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
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                SetProperty(ref _currentAccount, value, () => CurrentAccount);
            }
        }
        public string Ac
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        private int _electedIndex;
        public int SelectedIndex
        {
            get { return _electedIndex; }
            set
            {
                SetProperty(ref _electedIndex, value, () => SelectedIndex);
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

        public GameHelper GameHelper { get; set; }

        public int Level
        {
            get
            {
                if (_player != null)
                    return int.Parse(_player.playerLv);
                return 0;
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

        public bool IsSkipIfOne { get; set; }

        public List<套装> TaozhuangList { get; set; }

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
            int intX, intY;
            //_dm.FindMultiColor(258, 34, 854, 218, "d69f5a", "-8|5|3a3327,5|13|d5c484,21|14|cfbf80,29|6|2f2a1e,-10|1|352d20,-5|-2|c89b60,2|22|1f0201", 0.9, 0, out intX, out intY);
            _dm.FindMultiColor(258, 34, 854, 218, "ce9f61", "3|-1|e5be72,7|-15|30281c,-9|2|2f291d,-3|7|362f22,-1|-10|fce4a1,32|7|302a1e,7|17|e3d188,3|13|ecde96", 0.8, 0, out intX, out intY);
            //if (_dm.FindPicAndClick(258, 34, 854, 218,@"\bmp\特殊事件.bmp",37,15,0.7))
            if (intX > 0 && intY > 0)
            {
                _dm.MoveToClick(intX, intY);
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

        List<string> playerList = new List<string>();
        public bool ChangeRole()
        {
            OutMessage("切换角色中...");
            Delegater.WaitTrue(() => _dm.MoveToClick(29, 51), () => IsExistWindowMenu("角色"), () => { _dm.Delay(1000); CloseWindow(); });
            Delegater.WaitTrue(() =>
            {
                OpenWindowMenu("角色");
                return _dm.FindPicAndClick(446, 408, 580, 486, @"\bmp\切换角色.bmp|\bmp\切换角色2.bmp");

            }, () => _dm.IsExistPic(394, 416, 563, 486, @"\bmp\开始游戏.bmp|\bmp\开始游戏2.bmp", 0.8, false), () => _dm.Delay(1000));

            Delegater.WaitTrue(() =>
            {
                _dm.Delay(1000);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(500);
                _dm.Swipe(490, 337, 490, 128);
                _dm.Delay(1000);

                if (_dm.FindPicAndClick(312, 285, 646, 394, @"\bmp\等级.bmp"))
                {
                    _dm.Delay(500);
                    return _dm.FindPicAndClick(316, 289, 635, 482, @"\bmp\开始.bmp");
                }
                return false;
            });
            Delegater.WaitTrue(() =>
            {
                if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") || _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                {
                    while (_dm.IsExistPic(406, 378, 557, 432, @"\bmp\以后再说.bmp", 0.8))
                    {
                        _dm.MoveToClick(544, 414);
                        _dm.Delay(1000);
                    }
                    _dm.Delay(1000);
                    return true;
                }
                return false;
            }, () => _dm.Delay(1000));
            _dm.Delay(3000);
            Player = GameHelper.GetPlayer();
            if (Player != null)
            {
                if (!playerList.Contains(Player.playerName))
                {
                    playerList.Add(Player.playerName);
                }
                else
                {
                    if (playerList.Count >= 10)
                        return false;
                }
            }
            else
            {
                throw new Exception("未能获取到角色信息!");
            }
            return true;
        }

        public bool OpenRemind()
        {
            OutSubMessage("打开提醒...");
            if (_dm.FindPicAndClick(283, 33, 906, 301, @"\bmp\提醒.bmp"))
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
             }, () => _dm.Delay(1000), 5);

        }

        public bool OpenWindowMenu(string menu)
        {
            //未选中:45.34.60-5.5.20
            //选中:60.18.75-5.5.25
            return Delegater.WaitTrue(() =>
            {
                _dm.FindStrAndClick(75, 2, 909, 70, menu, "45.34.60-5.5.20");
                _dm.Delay(500);
                if (_dm.IsExistStr(75, 2, 909, 70, menu, "60.18.75-5.5.25"))
                    return true;
                return false;
            });
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
                                 () => _dm.Delay(1000), 2000);
        }
        public bool CloseMap()
        {
            return Delegater.WaitTrue(() => _dm.MoveToClick(920, 69),
                                 () => !_dm.IsExistStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25"),
                                 () => _dm.Delay(1000), 2000);
        }


        public bool OpenActivityBoard(string activity)
        {
            if (_dm.IsExistStr(75, 2, 909, 70, activity, "45.34.60-5.5.20|60.18.75-5.5.25"))
            {
                OutSubMessage("活动面板[" + activity + "]已经打开!");
                return Delegater.WaitTrue(() =>
                {
                    _dm.FindStrAndClick(75, 2, 909, 70, activity, "45.34.60-5.5.20");
                    _dm.Delay(500);
                    if (_dm.IsExistStr(75, 2, 909, 70, activity, "60.18.75-5.5.25"))
                        return true;
                    return false;
                }, () => _dm.Delay(500), 10);
            }
            else
                CloseWindow();

            string points = _dm.FindPicEx(286, 37, 875, 284, @"\bmp\活动2.bmp", "202020", 0.8, 0);
            Debug.WriteLine(points);

            if (points == "")
            {
                CloseWindow();
                return false;
            }
            string[] t = points.Split('|');

            foreach (var item in t)
            {
                string[] p = item.Split(',');
                _dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                _dm.Delay(1000);
                if (_dm.IsExistStr(75, 2, 909, 70, activity, "45.34.60-5.5.20|60.18.75-5.5.25"))
                {
                    return Delegater.WaitTrue(() =>
                    {
                        _dm.FindStrAndClick(75, 2, 909, 70, activity, "45.34.60-5.5.20");
                        _dm.Delay(500);
                        if (_dm.IsExistStr(75, 2, 909, 70, activity, "60.18.75-5.5.25"))
                            return true;
                        return false;
                    }, () => _dm.Delay(500), 10);
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
            int intX, intY;
            return Delegater.WaitTrue(() =>
            {
                switch (menu)
                {
                    case "资源":
                        if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"))
                            _dm.MoveToClick(760, 500);
                        if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"))
                            _dm.MoveToClick(382, 501);
                        break;
                    case "武将":
                        if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"))
                            _dm.MoveToClick(834, 499);
                        if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"))
                            _dm.MoveToClick(451, 504);
                        break;
                    case "国家":
                        Delegater.WaitTrue(() => _dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"),
                                           () => _dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"), () => _dm.Delay(1000), 2000, 10);
                        _dm.MoveToClick(530, 506);
                        break;
                    case "装备":
                        Delegater.WaitTrue(() => _dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"),
                                             () => _dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"), () => _dm.Delay(1000), 2000, 10);
                        _dm.MoveToClick(608, 503);
                        break;
                    case "科技":
                        Delegater.WaitTrue(() => _dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"),
                                             () => _dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"), () => _dm.Delay(1000), 2000, 10);
                        _dm.MoveToClick(680, 498);
                        break;
                    case "排行":
                        Delegater.WaitTrue(() => _dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"),
                                             () => _dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"), () => _dm.Delay(1000), 2000, 10);
                        _dm.MoveToClick(761, 494);
                        break;
                    case "兵器":
                        Delegater.WaitTrue(() => _dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"),
                                             () => _dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"), () => _dm.Delay(1000), 2000, 10);
                        _dm.MoveToClick(835, 497);
                        break;
                    default:
                        break;
                }

                _dm.Delay(1000);
                _dm.FindMultiColor(539, 0, 916, 298, "f4c792", "-11|4|be1a1c,-6|-7|fbd7c5,6|8|d9af79,-7|8|d6ab77,0|14|aa0305,-14|1|aa0305,13|-1|ac0507,1|-12|bb1719", 0.9, 0, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    return true;
                }
                return false;
            }, () => _dm.Delay(1000), 10);

        }


        public bool GoToMap(string map)
        {
            switch (map)
            {
                case "世界":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                    {
                        OutSubMessage("已经在世界界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\世界.bmp", 0, 0, 0.7),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"),
                               () => _dm.Delay(1000));
                    break;
                case "副本":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"))
                    {
                        OutSubMessage("已经在副本界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\副本.bmp", 0, 0, 0.7),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"),
                               () => _dm.Delay(1000));
                    break;
                case "主城":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") && _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                    {
                        OutSubMessage("已经在主城界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\主城.bmp", 0, 0, 0.7),
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

        public bool GoToMap30(string map)
        {
            switch (map)
            {
                case "副本":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && !_dm.IsExistPic(811, 302, 956, 450, @"\bmp\副本2.bmp", 0.9))
                    {
                        if (OpenMenu())
                        {
                            _dm.Delay(1000);
                            if (!_dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp", 0.9))
                            {
                                OutSubMessage("已经在副本界面!");
                                break;
                            }
                        }
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(811, 302, 956, 450, @"\bmp\副本2.bmp", 0, 0, 0.9),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && !_dm.IsExistPic(811, 302, 956, 450, @"\bmp\副本2.bmp", 0.9),
                               () => _dm.Delay(1000));
                    break;
                case "主城":
                    if (_dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") && !_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"))
                    {
                        OutSubMessage("已经在主城界面!");
                        break;
                    }
                    Delegater.WaitTrue(() => _dm.FindPicAndClick(818, 281, 953, 447, @"\bmp\主城.bmp"),
                               () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本2.bmp") && !_dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                               () => _dm.Delay(1000));
                    break;
                default:
                    OutSubMessage("输入地图错误,无法打开");
                    break;
            }
            _dm.Delay(2000);
            return true;
        }


        public bool GoToFubenArea(string area)
        {

            List<string> areas = new List<string>() { "虎牢关", "下邳", "官渡", "西蜀" };
            string currentArea = "";
            int intX, intY, i = 0;
            foreach (var a in areas)
            {
                _dm.FindPic(320, 453, 640, 534, @"\bmp\" + a + ".bmp", "303030", 0.7, 0, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    _dm.DebugPrint("当前位于副本区域[" + a + "]");
                    currentArea = a;
                    break;
                }
            }
            if (currentArea == area)
            {
                _dm.DebugPrint("已经在副本区域[" + area + "]");
                return true;
            }
            _dm.DebugPrint("正在移动到目标区域...");
            return Delegater.WaitTrue(() =>
            {
                _dm.FindPic(320, 453, 640, 534, @"\bmp\" + area + ".bmp", "303030", 0.7, 0, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    _dm.DebugPrint("已经在副本区域[" + area + "]");
                    return true;
                }
                else
                {
                    int index = areas.IndexOf(area);
                    foreach (var a in areas)
                    {
                        _dm.FindPic(320, 453, 640, 534, @"\bmp\" + a + ".bmp", "303030", 0.7, 0, out intX, out intY);
                        if (intX > 0 && intY > 0)
                        {
                            _dm.DebugPrint("当前位于副本区域[" + a + "]");
                            currentArea = a;
                            break;
                        }
                    }
                    int currentIndex = areas.IndexOf(currentArea);
                    if (index > currentIndex)
                        _dm.Swipe(670, 427, 93, 415);
                    if (index < currentIndex)
                        _dm.Swipe(93, 415, 670, 427);
                }
                return false;
            }, () => _dm.Delay(1000));
        }
        /// <summary>
        /// 关闭菜单
        /// </summary>
        /// <returns></returns>
        public bool CloseMenu()
        {
            return Delegater.WaitTrue(() =>
            {
                if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单未打开.bmp", 0.8, false))
                    return true;
                if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp", 0.8, false))
                    _dm.MoveToClick(918, 499);
                return false;
            }, () => _dm.Delay(1000), 10);
        }
        public bool OpenMenu()
        {
            return Delegater.WaitTrue(() =>
            {
                if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp", 0.8, false))
                    return true;
                if (_dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单未打开.bmp", 0.8, false))
                    _dm.MoveToClick(918, 499);
                return false;
            }, () => _dm.Delay(1000), 10);
        }

        private bool SupplementarySoldier(int x1, int y1, int x2, int y2, int a, int b)
        {
            if (_dm.GetColorNum(x1, y1, x2, y2, "BF6C61-202020", 1.0) < 50)
            {
                _dm.MoveToClick(a, b);
                _dm.Delay(500);
                return true;
            }
            return false;
        }
        public bool GoToFighting(bool isSkip = false)
        {
            Delegater.WaitTrue(() =>
              {
                //_dm.FindPicAndClick(395, 311, 574, 393, @"\bmp\上阵.bmp");
                if (!_dm.FindPicAndClick(116, 72, 936, 351, @"\bmp\战斗.bmp"))
                  {
                      _dm.FindMultiColorAndClick(122, 58, 318, 196, "ffb40b", "19|-17|ffb814,35|0|ffb40b-202020,34|-34|fff303-202020,25|-25|ffdd12,26|-4|ff8804,8|-7|ff9907,28|-29|ffe009", -17, 59);
                  }
                  if (_dm.IsExistPic(405, 190, 525, 251, @"\bmp\达到上限.bmp"))
                  {
                      _dm.MoveToClick(548, 360);
                      _dm.Delay(1000);
                  }
                  if (_dm.IsExistPic(394, 216, 567, 307, @"\bmp\VS.bmp"))
                  {
                      _dm.Delay(500);
                      _dm.MoveToClick(64, 50);//清除教程提示
                    Delegater.WaitTrue(() =>
                      {
                        //补充兵力
                        SupplementarySoldier(696, 156, 792, 180, 747, 112);
                          SupplementarySoldier(564, 154, 658, 180, 610, 118);
                          SupplementarySoldier(433, 156, 531, 179, 485, 111);
                          SupplementarySoldier(304, 157, 395, 178, 355, 106);
                          SupplementarySoldier(175, 157, 263, 180, 219, 111);
                          _dm.Delay(500);
                          _dm.MoveToClick(807, 259); //点击开战
                        _dm.Delay(1000);
                          if (_dm.IsExistPic(319, 197, 448, 247, @"\bmp\兵力不足.bmp"))
                          {
                              _dm.MoveToClick(548, 360);
                              _dm.Delay(1000);
                              return false;
                          }
                          else
                              return true;
                      }, () => _dm.IsExistPic(5, 40, 48, 102, @"\bmp\攻方.bmp", 0.7),
                         () => _dm.Delay(1000));  //点击战斗

                    战术 tactics, recentTactics = 战术.无法识别;
                      while (true)
                      {
                          if (!_dm.IsExistPic(394, 216, 567, 307, @"\bmp\VS.bmp", 0.8, false) && _dm.IsExistPic(762, 4, 953, 87, @"\bmp\返回.bmp", 0.8, false) && isSkip)
                          {
                              _dm.MoveToClick(840, 43); //点击跳过
                            _dm.Delay(3000);
                          }
                          if (_dm.IsExistPic(330, 45, 639, 184, @"\bmp\胜利.bmp", 0.8, false))
                              return true;
                          if (_dm.IsExistPic(318, 36, 637, 195, @"\bmp\失败.bmp", 0.8, false))
                              return true;
                          tactics = GetLastTactics();  //获取战术
                        if (tactics >= 0)
                              recentTactics = tactics;
                          if (_dm.IsExistPic(310, 132, 445, 295, @"\bmp\战斗选择.bmp", 0.8, false))
                          {
                              if (!_dm.FindMultiColorAndClick(330, 119, 637, 416, "828175", "-53|53|a5a5a0,56|42|828274-202020,37|11|443a3b-202020,-42|21|fffeff,57|62|685b5a,-39|18|fffefe,-49|37|dbd8cd", 0, 0, 0.9))
                              {
                                  switch (recentTactics)
                                  {
                                      case 战术.防御:
                                          _dm.MoveToClick(581, 316);//点击攻击
                                        break;
                                      case 战术.突击:
                                          _dm.MoveToClick(370, 318);//点击防御
                                        break;
                                      case 战术.攻击:
                                          _dm.MoveToClick(474, 152);//点击突击
                                        break;
                                      default:
                                          _dm.DebugPrint("战术无法识别！");
                                          break;
                                  }

                              }
                          }
                          _dm.Delay(1000);

                      }
                  }
                  return false;
              });
            if (_dm.IsExistPic(330, 45, 639, 184, @"\bmp\胜利.bmp"))
            {
                _dm.MoveToClick(916, 45); //点击返回
                _dm.Delay(1000);
                return true;
            }
            if (_dm.IsExistPic(318, 36, 637, 195, @"\bmp\失败.bmp"))
            {
                Delegater.WaitTrue(() => _dm.MoveToClick(916, 45),
                    () => _dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") || _dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"),
                    () => _dm.Delay(1000));
                return false;
            }
            return false;
        }

        private 战术 GetLastTactics()
        {
            if (_dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗防御.bmp", 0.8, false) || _dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗强化防御.bmp", 0.8, false))
            {
                _dm.DebugPrint("对方使用防御!");
                return 战术.防御;
            }
            if (_dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗突击.bmp", 0.8, false) || _dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗强化突击.bmp", 0.8, false))
            {
                _dm.DebugPrint("对方使用突击!");
                return 战术.突击;
            }
            if (_dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗攻击.bmp", 0.8, false) || _dm.IsExistPic(393, 0, 577, 62, @"\bmp\战斗强化攻击.bmp", 0.8, false))
            {
                _dm.DebugPrint("对方使用攻击!");
                return 战术.攻击;
            }
            return 战术.无法识别;
        }

    }
    enum 战术
    {
        无法识别 = -1,
        防御,
        突击,
        攻击
    }
    enum 当前位置
    {
        World,
        MainCity,
        InstanceZones,
        Unknown
    }
   public enum Activity
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
