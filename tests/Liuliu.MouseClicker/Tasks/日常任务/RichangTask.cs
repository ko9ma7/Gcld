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

namespace Liuliu.MouseClicker.Tasks
{
    public class RichangTask : TaskBase
    {
        public RichangTask(TaskContext context) : base(context)
        {
           
        }

        protected override int GetStepIndex(TaskContext context)
        {
           
            return 1;
        }
     

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="领取军资",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="领取登录奖励",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="领取俸禄",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="祭祀资源",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="领取恭贺奖励",Order=5,RunFunc=RunStep5 },
                new TaskStep() {Name="领取礼包",Order=6,RunFunc=RunStep6 },
               // new TaskStep() {Name="集市购买",Order=7,RunFunc=RunStep7 },
             };
            return steps;
        }
        private TaskResult RunStep7(TaskContext arg)
        {
            Role role = (Role)Role;

            Delegater.WaitTrue(() =>
            {
                if(Dm.IsExistPic(864,446,960,542, @"\bmp\菜单未打开.bmp"))
                {
                    Dm.MoveToClick(756, 503);
                    Dm.Delay(1000);
                    return true;
                }
                return false;
            },() => role.IsExistWindowMenu("集市"),() => Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenWindowMenu("集市"),
                               () => Dm.IsExistPic(97,60,217,113, @"\bmp\购买次数.bmp"),
                               () => Dm.Delay(1000));
           
            Dm.UseDict(1);
            Dm.Delay(1000);
            int intX, intY;
            Delegater.WaitTrue(() =>
            {
                int result = Dm.GetOcrNumber(178, 72, 212, 109, "49A031-152F0F");
                if (result > 0)
                {
                    int type1=Dm.FindPic(160, 129, 346, 377, @"\bmp\粮食.bmp|\bmp\木材.bmp|\bmp\募兵令.bmp|\bmp\招商令.bmp|\bmp\镔铁.bmp", "202020", 0.8,0, out intX, out intY);
                    switch(type1)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            Dm.MoveToClick(250, 356);
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case -1:
                            break;
                    }
                    Dm.Delay(1000);
                    int type2 = Dm.FindPic(395, 132, 573, 373, @"\bmp\粮食.bmp|\bmp\木材.bmp|\bmp\募兵令.bmp|\bmp\招商令.bmp|\bmp\镔铁.bmp", "202020", 0.8, 0, out intX, out intY);
                    Debug.WriteLine(type2);
                    switch (type1)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            Dm.MoveToClick(487,356);
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case -1:
                            break;
                    }
                    Dm.Delay(1000);
                    int type3 = Dm.FindPic(630, 131, 810, 377, @"\bmp\粮食.bmp|\bmp\木材.bmp|\bmp\募兵令.bmp|\bmp\招商令.bmp|\bmp\镔铁.bmp", "202020", 0.8, 0, out intX, out intY);
                    Debug.WriteLine(type3);
                    switch (type1)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            Dm.MoveToClick(728,357);
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case -1:
                            break;
                    }
                    Dm.Delay(1000);
                    if (type1==2||type2==2||type3==2)


                    Dm.Delay(500);
                    return false;
                }
                else if (result == 0)
                    return true;
                else
                {
                    role.OutSubMessage("数字识别失败!");
                    if (Dm.FindPicAndClick(475, 315, 628, 415, @"\bmp\取消.bmp"))
                    {
                        Dm.Delay(1000);
                    }
                    return true;
                }
            }, () => Dm.Delay(50), 40);
            Dm.UseDict(0);
            role.CloseWindow();
            return TaskResult.Success;
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
            role.OpenMenu(@"\bmp\资源|bmp\资源2.bmp");
            Delegater.WaitTrue(() => role.OpenWindowMenu("祭祀"),
                               () => Dm.GetColorNum(204, 61, 278, 96, "cba300-303030", 0.9)>10,
                               () => Dm.Delay(1000));

            Dm.FindPicAndClick(699, 63, 868, 118, @"\bmp\祭祀十次.bmp");
            Dm.Delay(1000);
            Delegater.WaitTrue(() =>
                 {
                   if(Dm.GetColorNum(738, 500, 761, 522, "79a03b-303030", 0.9)>20)
                     {
                         Dm.MoveToClick(783, 512);
                         Dm.Delay(500);
                         return false;
                     }
                     return true;
                 }, () => Dm.Delay(50), 10);
            Dm.UseDict(1);
            Delegater.WaitTrue(() =>
            {
                    if (Dm.GetOcrNumber(204, 61, 278, 96, "C59E00-3A2E00") > 0)
                    {
                        Dm.MoveToClick(322, 451);
                        Dm.Delay(500);
                        return false;
                    }
                    else
                    {
                        role.OutSubMessage("数字识别失败!");
                        if (Dm.FindPicAndClick(475, 315, 628, 415, @"\bmp\取消.bmp"))
                        {
                            Dm.Delay(1000);
                        }
                        return true;
                    }
            },()=>Dm.Delay(50),40);
            Dm.UseDict(0);
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep5(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenTeshushijian();
            if (Dm.FindPicAndClick(114, 142, 827, 489, @"\bmp\恭贺奖励.bmp", 30, 0))
            {
                Dm.Delay(1000);
                int count = 30;
                while (true)
                {
                    while (Dm.IsExistPic(339, 76, 577, 146, @"\bmp\恭贺.bmp")&&count!=0)
                    {
                        Dm.MoveToClick(478, 477);
                        Dm.Delay(300);
                        count--;
                    }
                    Dm.Delay(2000);
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
