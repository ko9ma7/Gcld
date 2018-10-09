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
           
            return 4;
        }
        protected override void OnStopping(TaskContext context)
        {
            ((Role)Role).ChangeRole();
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="领取军资",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="领取登录奖励",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="领取恭贺奖励",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="领取俸禄",Order=4,RunFunc=RunStep4 }
             };
            return steps;
        }

        private TaskResult RunStep4(TaskContext arg)
        {
            return TaskResult.Success;
            Role role = (Role)Role;
            role.OpenTixing();
            if (Dm.FindPicAndClick(102, 132, 836, 494, @"\bmp\领取俸禄.bmp"))
            {
                Dm.Delay(1000);
                Dm.MoveToClick(657, 476);
                Dm.Delay(2000);
            }
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep3(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenTeshushijian();
            if (Dm.FindPicAndClick(114, 142, 827, 489, @"\bmp\恭贺奖励.bmp", 30, 0))
            {
                Dm.Delay(1000);
                while(Dm.IsExistPic(339, 76, 577, 146, @"\bmp\恭贺.bmp"))
                {
                    Dm.MoveToClick(492, 487);
                    Dm.Delay(300);
                }
            }
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep2(TaskContext arg)
        {
            Role role = (Role)Role;
            role.OpenTixing();
            if (Dm.FindPicAndClick(108, 126, 831, 493, @"\bmp\每日登陆.bmp"))
            {
                Dm.Delay(1000);
                Dm.MoveToClick(523,411);
                Dm.Delay(3000);
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
            IRole role = context.Role;
            DmPlugin dm = role.Window.Dm;
            dm.MoveToClick(947, 69);
            dm.Delay(1000);

            int intX, intY;
            for (int i = 0; i < 100; i++)
            {
              
                dm.FindStr(70, 232, 216, 291, "军资奖励", "44.34.64-10.10.25", 0.9, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    dm.MoveToClick(152, 432);
                    dm.Delay(50);
                    if(dm.GetColorNum(160, 249, 231, 300, "f60000-101010",0.9)>5)
                    {
                        role.OutSubMessage("军资已经领取完成,正在冷却!");
                        break;
                    }

                }else
                {
                    role.OutMessage("找不到军资奖励");
                }
            }
            role.OutSubMessage("关闭地图中...");
            dm.MoveToClick(947, 69);
            dm.Delay(1000);


            return TaskResult.Success;
        }
    }
}
