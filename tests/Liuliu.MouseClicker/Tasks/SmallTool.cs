using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Damo;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Tasks
{
    public class SmallTool : TaskBase
    {
        public SmallTool(TaskContext context) : base(context)
        {
        
        }

        protected override int GetStepIndex(TaskContext context)
        {
            try
            {
                if (context.Settings.IsAutoWeapon)
                {
                    return 1;
                }
            } catch{ }
            try
            {
                if (context.Settings.IsAutoClear)
                {
                    return 3;
                }
            }
            catch { }
            try
            {
                if (context.Settings.IsAutoBuilding)
                {
                    return 2;
                }
            }
            catch { }
            try
            {
                if (context.Settings.IsRefreshEquipment)
                {
                    return 4;
                }
            }
            catch { }
            try
            {
                if (context.Settings.IsAutoClear2)
                {
                    equipmentType = context.Settings.EquipmentType;
                    return 5;
                }
            }
            catch { }
            return 1;
        }
        private int equipmentType = -1;
        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动兵器",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="自动建筑",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="自动洗练",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="刷新装备",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="指定洗练",Order=5,RunFunc=RunStep5 },

             };
            return steps;
        }
        enum EquipmentType
        {
            未知类型 = -1,
            攻击,
            防御,
            掌控,
            血量,
            强防,
            强壮,
            强攻
        }
        private EquipmentType GetEquipmentType()
        {
            int intX, intY;
            int result = Dm.FindPic(781, 315, 861, 402, @"\bmp\攻击.bmp|\bmp\防御.bmp|\bmp\掌控.bmp|\bmp\血量.bmp|\bmp\强防.bmp|\bmp\强壮.bmp|\bmp\强攻.bmp|", "202020", 0.8, 0, out intX, out intY);
            return (EquipmentType)result;
        }
        class Equipment
        {
            public EquipmentType 类型;
            public bool IsHave=false;
        }
        class 套装
        {
            public Equipment 麒麟双枪;
            public Equipment 麒麟;
            public Equipment 三昧纯阳铠;
            public Equipment 蝶凤舞阳;
            public Equipment 伏龙帅印;
            public Equipment 蟠龙华盖;
        }

        private TaskResult RunStep5(TaskContext context)
        {
            Role role = (Role)context.Role;
            
            套装 青龙套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.血量 }, 麒麟 = new Equipment() { 类型 = EquipmentType.血量 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.血量 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.血量 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.血量 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.血量 }};
            套装 白虎套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 }};
            套装 朱雀套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强壮 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强壮 }};
            套装 鲮鲤套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.掌控 }, 麒麟 = new Equipment() { 类型 = EquipmentType.掌控 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.掌控 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强防 }};
            套装 玄武套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.防御 }, 麒麟 = new Equipment() { 类型 = EquipmentType.防御 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.防御 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.防御 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.防御 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.防御 }};
            套装 霸下套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强防 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强防 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.掌控 }};
            套装 驱虎套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 }};
            套装 烛龙套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强防 }};
            套装 凤凰套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 }};
            套装 灵龟套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强攻 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强攻 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.掌控 }};
            List<套装> list = new List<套装>() { 青龙套装, 白虎套装, 朱雀套装, 鲮鲤套装, 玄武套装, 霸下套装, 驱虎套装, 烛龙套装, 凤凰套装, 灵龟套装 };
           
        Delegater.WaitTrue(() =>
            {
              Dm.MoveToClick(631, 448);
              Dm.Delay(500);
              if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp"))
              {
                Dm.Delay(500);
               }
               if(Dm.IsExistPic(379,213,475,255,@"\bmp\隐藏技能.bmp"))
                {
                    var type = GetEquipmentType();
                    Dm.DebugPrint("需要的类型:" + ((EquipmentType)equipmentType).ToString());
                    Dm.DebugPrint("当前类型:" + type.ToString());
                    var taozhuang = list.FirstOrDefault(x => x.麒麟双枪.类型 == type&&x.麒麟双枪.IsHave==false);
                    if (taozhuang!=null)
                    {
                        taozhuang.麒麟双枪.IsHave = true;
                    }
             

                    if(type != EquipmentType.未知类型)
                    {
                        if ((int)type == equipmentType)
                            return true;
                        else
                            Dm.MoveToClick(409,362);
                        Dm.Delay(500);
                    }
                }
                return false;
            });
            return TaskResult.Finished;
        }

        private TaskResult RunStep4(TaskContext context)
        {
            Role role = (Role)context.Role;
            Delegater.WaitTrue(() => Dm.FindPicAndClick(856, 448, 958, 536, @"\bmp\菜单未打开.bmp"),
                               () => Dm.IsExistPic(856, 448, 958, 536, @"\bmp\菜单打开.bmp"),()=>Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenMenu("装备"),
                              () => role.OpenWindowMenu ("商店"),() => Dm.Delay(1000));
            Delegater.WaitTrue(() =>
            {
                Dm.FindStrAndClick(718, 448, 857, 502,"刷新", "86.17.70-5.5.25");
                if(Dm.IsExistPic(283,192,668,411,@"\bmp\金币秒CD.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    return true;
                }
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\适合您的装备.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\稀有物品.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                return Dm.IsExistStr(718, 448, 857, 502, "清除", "86.17.70-5.5.25");
            },()=>Dm.Delay(500));
            role.CloseWindow();
            return TaskResult.Finished;
        }
       
        private TaskResult RunStep3(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;

            Delegater.WaitTrue(() =>
            {
                string points = Dm.FindPicEx(98, 120, 556, 513, @"\bmp\星星3.bmp", "202020", 0.8, 0);
                Debug.WriteLine(points);
                if (points == "")
                {
                    return true;
                }
                string[] t = points.Split('|');

                foreach (var item in t)
                {
                    string[] p = item.Split(',');
                    Dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                    Dm.Delay(1000);
                    if (Dm.IsExistPic(707, 382, 734, 404, @"\bmp\星星1.bmp"))
                    {
                        if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp"))
                        {
                            continue;
                        }
                        while (true)
                        {
                            Dm.MoveToClick(631, 448);
                            Dm.Delay(500);
                            if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp"))
                            {
                                Dm.Delay(1000);
                                break;
                            }
                        }
                    }  
                }
                Dm.Swipe(515, 438, 515, 220, 50);

                return false;
            });
            return TaskResult.Finished;
        }
        private TaskResult RunStep2(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            if(dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && 
               dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") &&
               dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"))
            {
                role.OutSubMessage("在建筑中...");
            }
            else
            {
                role.GoToMap("主城");
                //dm.MoveToClick(317, 460);//点击兵营
                dm.MoveToClick(419, 245);//点击银币
                //dm.MoveToClick(200, 200);//点击木材
                dm.Delay(2000);
            }
            string a, b;
            dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
            dm.Delay(1000);
            Delegater.WaitTrue(() =>
            {
               a=dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp",0,0,0.7))
                {
                    dm.DebugPrint("不存在加速锤！等待5s");
                    dm.MoveToClick(152, 429);
                    dm.Delay(5000);
                }
                dm.Delay(500);
                b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                if (a!=b)
                {
                    dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                }
                return false;
            });
            return TaskResult.Finished;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开兵器界面");

            Delegater.WaitTrue(() =>
            {
                int a = Dm.GetColorNum(113, 83, 173, 135, "e25858 - 202020", 0.9);
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                return a > 10;
            }, () =>
            {
                Dm.MoveToClick(409, 181);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int b = Dm.GetColorNum(104, 229, 187, 286, "e25858 - 202020", 0.9);
                return b > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 326);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int c = Dm.GetColorNum(110, 374, 181, 433, "e25858 - 202020", 0.9);
                return c > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 471);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int d = Dm.GetColorNum(478, 86, 559, 144, "e25858 - 202020", 0.9);
                return d > 10;
            }, () =>
            {
                Dm.MoveToClick(790, 182);
                Dm.Delay(200);
            });
            int i = 0;
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int e = Dm.GetColorNum(500, 249, 533, 269, "c2d3af-202020", 0.9);
                if(e<10)
                {
                    Dm.Delay(2000);
                    if(Dm.GetColorNum(500, 249, 533, 269, "c2d3af-202020", 0.9)<10)
                    {
                        return true;
                    }
                }
                return false;
            }, () =>
            {
                Dm.MoveToClick(787, 326);
                Dm.Delay(300);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int f = Dm.GetColorNum(489, 383, 559, 426, "e25858 - 202020", 0.9);
                return f > 10;
            }, () =>
            {
                Dm.MoveToClick(785, 470);
                Dm.Delay(200);
            });

            return TaskResult.Finished;
            
        }
    }
}
