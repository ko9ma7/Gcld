using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using Liuliu.ScriptEngine.Damo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.ViewModels;

namespace Liuliu.MouseClicker.Tasks
{
    public class RichangTask : TaskBase
    {
        RoleSettingViewModel settingViewModel = null;
        public RichangTask(TaskContext context) : base(context)
        {
            settingViewModel = LocalDataHandler.GetData<RoleSettingViewModel>("data.db", "roleSetting");
        }

        protected override int GetStepIndex(TaskContext context)
        {
            return 1;
        }
        protected override TaskResult OnStepIsCanRun(string name)
        {
            var func = settingViewModel.UtilList.FirstOrDefault(x => x.FunctionName == name&&x.IsChecked==true);
            if (func != null)
            {
                return TaskResult.Success;
            }
            return TaskResult.Jump;
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name=DailyTasksEnum.领取军资.ToString(),Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name=DailyTasksEnum.登录奖励.ToString(),Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name=DailyTasksEnum.领取恭贺.ToString(),Order=3,RunFunc=RunStep5 },
                new TaskStep() {Name=DailyTasksEnum.祭祀资源.ToString(),Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name=DailyTasksEnum.领取礼包.ToString(),Order=5,RunFunc=RunStep6 },
                new TaskStep() {Name=DailyTasksEnum.领取俸禄.ToString(),Order=6,RunFunc=RunStep3 },
                new TaskStep() {Name=DailyTasksEnum.集市购买.ToString(),Order=7,RunFunc=RunStep7 },
                new TaskStep() {Name=DailyTasksEnum.自动宴会.ToString(),Order=8,RunFunc=RunStep8 },
            };
            return steps;
        }
        private TaskResult RunStep8(TaskContext arg)
        {
            Role role = (Role)Role;
            Dm.UseDict(0);
            Delegater.WaitTrue(() => role.OpenMenu("武将"), () => role.IsExistWindowMenu("宴会"), () => Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenWindowMenu("宴会"),
                               () => Dm.Delay(1000));

         
            return TaskResult.Success;
        }


        private TaskResult RunStep7(TaskContext arg)
        {
                Role role = (Role)Role;
                Dm.UseDict(0);
                Delegater.WaitTrue(() => role.OpenMenu("资源"), () => role.IsExistWindowMenu("集市"), () => Dm.Delay(1000));
                Delegater.WaitTrue(() => role.OpenWindowMenu("集市"),
                                   () => Dm.Delay(1000));

                Dm.UseDict(1);
                Dm.Delay(1000);
                Delegater.WaitTrue(() =>
                {
                    bool result = Dm.IsChangeColorNumEx(170, 72, 237, 107, "49A031-152F0F", () =>
                           {
                               Dm.StartWatch();
                               var rt1 = GetResourceType(160, 129, 346, 377);
                               var rc1 = GetColor(176, 119, 328, 178);
                               Dm.DebugPrint("第一个资源：" + rt1.ToString() + ",颜色：" + rc1.ToString());

                               var rt2 = GetResourceType(395, 132, 573, 373);
                               var rc2 = GetColor(409, 129, 566, 175);
                               Dm.DebugPrint("第二个资源：" + rt2.ToString() + ",颜色：" + rc2.ToString());

                               var rt3 = GetResourceType(630, 131, 810, 377);
                               var rc3 = GetColor(633, 124, 804, 180);
                               Dm.DebugPrint("第三个资源：" + rt3.ToString() + ",颜色：" + rc3.ToString());
                               Dm.StopWatch();
                               Dm.StartWatch();
                               List<Resource> list = new List<Resource>()
                                {
                                   new Resource() { Pos=1,Type=rt1,Color=rc1,Buypos=new Tuple<int, int>(253,353) },
                                   new Resource() { Pos=2,Type=rt2,Color=rc2,Buypos=new Tuple<int, int>(495,353) },
                                   new Resource() { Pos=3,Type=rt3,Color=rc3,Buypos=new Tuple<int, int>(727,353) }
                                };
                               var rlist = list.OrderByDescending(q => q.Type).ThenByDescending(x => x.Color).ToList();
                               Dm.DebugPrint(string.Format("购买位置：{0},资源类型:{1},资源颜色:{2}", rlist.First().Pos, rlist.First().Type.ToString(), rlist.First().Color.ToString()));
                               Dm.MoveToClick(rlist.First().Buypos.Item1, rlist.First().Buypos.Item2);
                               Dm.StopWatch();
                               Dm.Delay(1000);
                           });
                    if(!result)
                    {
                        Dm.DebugPrint("操作完颜色结果不变,可能已经完成!~");
                        if(Dm.IsExistPic(171,71,247,105,@"\bmp\集市0.bmp"))
                            return true;
                    }
                    if (Dm.FindPicAndClick(475, 315, 628, 415, @"\bmp\取消.bmp"))
                    {
                        Dm.Delay(1000);
                    }
                    return false;
                }, () => Dm.Delay(50), 40);
            Dm.UseDict(0);
            role.CloseWindow();
            return TaskResult.Success;
        }

        class Resource
        {
           public int Pos { get; set; }
           public Color Color { get; set; }
           public ResourceType Type { get; set; }
           public Tuple<int, int> Buypos { get; set; }
        }
        enum ResourceType
        {
            无法识别=-1,
            招商令,
            镔铁,
            粮食,
            木材,
            募兵令,
        }
        enum Color
        {
            无法识别 = -1,
            白,
            蓝,
            绿,
            黄,
            红,
            紫,
        }
        private ResourceType GetResourceType(int x1,int y1,int x2,int y2)
        {
            int intX, intY;
            int type = Dm.FindPic(x1, y1, x2, y2, @"\bmp\招商令.bmp|\bmp\镔铁.bmp|\bmp\粮食.bmp|\bmp\木材.bmp|\bmp\募兵令.bmp", "303030", 0.8, 0, out intX, out intY);
           // Dm.DebugPrint("资源类型：" + type.ToString());
            return (ResourceType)type;
        }
        private Color GetColor(int x1, int y1, int x2, int y2)
        {
            int intX, intY;
           // int 白色数量=0, 蓝色数量=0, 绿色数量=0, 黄色数量=0, 红色数量=0, 紫色数量=0;
            if (Dm.FindColor(x1, y1, x2, y2, "D1D1D1-303030", 1.0, 0, out intX, out intY))
                return Color.白;
            //白色数量 = Dm.GetColorNum(x1, y1, x2, y2, "D1D1D1-2D2D2D", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "698EC6-111821", 1.0, 0, out intX, out intY))
                return Color.蓝;
            //蓝色数量 = Dm.GetColorNum(x1, y1, x2, y2, "698EC6-111821", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "5CB52C-15290B", 1.0, 0, out intX, out intY))
                return Color.绿;
            // 绿色数量 = Dm.GetColorNum(x1, y1, x2, y2, "5CB52C-15290B", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "CD9735-31250D", 1.0, 0, out intX, out intY))
                return Color.黄;
           // 黄色数量 = Dm.GetColorNum(x1, y1, x2, y2, "CD9735-31250D", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "C44C4C-341414", 1.0, 0, out intX, out intY))
                return Color.红;
            //红色数量 = Dm.GetColorNum(x1, y1, x2, y2, "C44C4C-341414", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "A85EC2-2A1730", 1.0, 0, out intX, out intY))
                return Color.紫;
            //紫色数量 = Dm.GetColorNum(x1, y1, x2, y2, "A85EC2-2A1730", 0.9, true);
           // int[] 颜色数量 = new int[] { 白色数量, 蓝色数量, 绿色数量, 黄色数量,红色数量, 紫色数量 };
           // int max = 颜色数量.Max();
            // return (Color)颜色数量.ToList().IndexOf(max);
            return Color.无法识别;
        }
     
        private TaskResult RunStep6(TaskContext arg)
        {
            Role role = (Role)Role;
            if (Dm.GetColorNum(523, 379, 602, 450, "dc3146-303030", 0.9) > 50)
            {
                Delegater.WaitTrue(() => Dm.MoveToClick(30, 32),
                                   () => role.IsExistWindowMenu("设置"),
                                   () => Dm.Delay(1000));
                Delegater.WaitTrue(() => role.OpenWindowMenu("设置"),
                                 () => Dm.IsExistPic(507, 99, 583, 163, @"\bmp\礼包.bmp"),
                                     () => Dm.Delay(1000));
                Delegater.WaitTrue(() =>
                {
                    Dm.FindPicAndClick(507, 99, 583, 163, @"\bmp\礼包.bmp");
                    Dm.Delay(1000);
                    if (Dm.FindPicAndClick(678, 241, 811, 344, @"\bmp\宝箱.bmp"))
                    {
                        Dm.Delay(2000);
                    }
                    else
                        return true;
                    return false;
                }, () => Dm.Delay(1000), 10);
            }

            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep4(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenMenu("资源");
            Delegater.WaitTrue(() => role.OpenWindowMenu("祭祀"),
                               () => role.IsExistWindowMenu("祭祀"),
                               () => Dm.Delay(1000));

            Dm.FindPicAndClick(699, 63, 868, 118, @"\bmp\祭祀十次.bmp");
            Dm.Delay(1000);
            Delegater.WaitTrue(() =>
                 {
                   if(Dm.GetColorNum(738, 500, 761, 522, "79a03b-303030", 1.0)>20)
                     {
                         Dm.MoveToClick(783, 512);
                         Dm.Delay(1000);
                         return false;
                     }
                     return true;
                 }, () => Dm.Delay(50), 10);
            Dm.UseDict(1);

            Delegater.WaitTrue(() =>
            {
                if (Dm.IsExistPic(197, 59, 288, 102, @"\bmp\祭祀0.bmp", 0.7))
                {
                    if(Dm.GetColorNum(204, 61, 278, 96, "C59E00-3A2E00",0.9)<75)
                      return true;
                }
                bool result=Dm.IsChangeColorNumEx(204, 61, 278, 96, "C59E00-3A2E00", () =>
                {
                     Dm.MoveToClick(322, 451);//祭祀木材
                    //Dm.MoveToClick(162, 454);//祭祀银子
                    Dm.Delay(500);
                });
                if(!result)
                {
                    Dm.DebugPrint("操作完颜色结果不变,可能已经完成!~");
                    if (Dm.FindPicAndClick(475, 315, 628, 415, @"\bmp\取消.bmp"))
                    {
                        Dm.Delay(1000);
                    }
                    return true;
                }
                return false;
            },()=>Dm.Delay(50),40);
            Dm.UseDict(0);
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep5(TaskContext arg)
        {
            Role role = (Role)Role;
            Delegater.WaitTrue(()=> role.OpenTeshushijian(),
                               ()=>Dm.IsExistPic(370,81,595,139, @"\bmp\特殊事件3.bmp"),
                               ()=>Dm.Delay(1000)) ;
            if (Dm.FindPicAndClick(114, 142, 827, 489, @"\bmp\恭贺奖励.bmp", 30, 0))
            {
                Dm.Delay(1000);
                int count = 20;
                while (true)
                {
                    while (Dm.IsExistPic(339, 76, 577, 146, @"\bmp\恭贺.bmp")&&count!=0)
                    {
                        Dm.MoveToClick(478, 477);
                        Dm.Delay(300);
                        count--;
                    }
                    Dm.Delay(1000);
                    if (!Dm.IsExistPic(339, 76, 577, 146, @"\bmp\恭贺.bmp"))
                        break;
                    if (count == 0)
                        break;
                }
            }
            role.CloseWindow();
           return TaskResult.Success;
        }

        private TaskResult RunStep3(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenRemind();
            if (Dm.FindPicAndClick(102, 132, 836, 494, @"\bmp\领取俸禄.bmp"))
            {
                Dm.Delay(1000);
                Dm.MoveToClick(657, 476);
                Dm.Delay(2000);
            }
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep2(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenRemind();
            if (Dm.FindPicAndClick(98, 133, 868, 516, @"\bmp\每日登陆.bmp"))
            {
                Dm.Delay(1000);
                Dm.MoveToClick(513,402);
                Dm.Delay(1000);
            }
            else
            {
                role.CloseWindow();
                return TaskResult.Success;
            }
            role.CloseWindow();
            return RunStep2(arg);
        }

        private TaskResult RunStep1(TaskContext context)
        {
  
           
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            
            role.GoToMap("世界");
            role.CloseWindow();
            dm.Delay(1000);
            if(Dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单打开.bmp"))
            Delegater.WaitTrue(() => Dm.FindPicAndClick(862, 454, 961, 537, @"\bmp\菜单打开.bmp"),
                                           () => Dm.IsExistPic(862, 454, 961, 537, @"\bmp\菜单未打开.bmp"), 
                                           () => Dm.Delay(1000), 2000);
            role.OpenMap();

            int intX, intY;
            while(true)
            {
                dm.FindStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25", 0.9, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    role.OutSubMessage("领取军资...");
                    dm.MoveToClick(156, 420);
                    dm.Delay(50);
                    if(dm.GetColorNum(157, 242, 227, 293, "f60000-101010",0.9)>5)
                    {
                        role.OutSubMessage("军资已经领取完成,正在冷却!");
                        break;
                    }
                    dm.Delay(300);
                }else
                {
                    role.OutSubMessage("找不到军资奖励");
                    break;
                }
            }
         
            role.CloseMap();

            return TaskResult.Success;
        }
    }
}
