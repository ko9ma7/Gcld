﻿using Liuliu.ScriptEngine;
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
        protected override void OnStopping(TaskContext context)
        {
          
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="领取军资",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="领取登录奖励",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="领取俸禄",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="领取恭贺奖励",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="祭祀资源",Order=5,RunFunc=RunStep5 }
             };
            return steps;
        }

        private TaskResult RunStep5(TaskContext arg)
        {
            throw new NotImplementedException();
        }

        private TaskResult RunStep4(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenTeshushijian();
            if (Dm.FindPicAndClick(114, 142, 827, 489, @"\bmp\恭贺奖励.bmp", 30, 0))
            {
                Dm.Delay(1000);
                int count = 30;
                while (Dm.IsExistPic(339, 76, 577, 146, @"\bmp\恭贺.bmp")&&count!=0)
                {
                    Dm.MoveToClick(478, 477);
                    Dm.Delay(300);
                    count--;
                }
            }
            role.CloseWindow();
            if (Repetitions == 9)
            {
               return TaskResult.Finished;
            }
            else
            {
                role.ChangeRole();
                Dm.Delay(5000);
               
                return TaskResult.Success;
            }
          
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

            Dm.FindPicAndClickClear(799, 328, 965, 520, @"\bmp\世界.bmp");
                      
            role.OpenMap();

            int intX, intY;
            while(true)
            {
                dm.FindStr(75, 246, 227, 296, "军资奖励", "44.34.64-10.10.25", 0.9, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
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
                    role.OutMessage("找不到军资奖励");
                    break;
                }
            }
         
            role.CloseMap();

            return TaskResult.Success;
        }
    }
}
