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
    public class HuodongTask : TaskBase
    {
        public HuodongTask(TaskContext context) : base(context)
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
                new TaskStep() {Name="大宴群雄",Order=1,RunFunc=RunStep1 }
             };
            return steps;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开活动界面");

            Delegater.WaitTrue(() =>
            {
                return role.OpenActivityBoard("大宴群雄");
            },()=> {
                return Dm.IsExistPic(266, 83, 692, 160, @"\bmp\大宴群雄.bmp");
            },()=>Dm.Delay(1000));
 


            Delegater.WaitTrue(() =>
            {
                Dm.FindStrAndClick(494, 445, 702, 515, "免费", "DAD8D3-25272C", 100, 10);
                Dm.Delay(300);
                Dm.FindPicAndClick(494, 445, 702, 515, @"\bmp\免费请帖.bmp", 100, 36);
                Dm.Delay(300);
                Dm.FindPicAndClick(258, 452, 447, 518, @"\bmp\免费盛宴.bmp", 100, 10);
                Dm.Delay(300);
                Dm.FindPicAndClick(258, 452, 447, 518, @"\bmp\随机邀请.bmp");
                Dm.Delay(300);
                if (Dm.IsExistPic(494, 445, 702, 515, @"\bmp\金币邀请.bmp") && Dm.IsExistPic(258, 452, 447, 518, @"\bmp\金币盛宴.bmp"))
                {
                    role.OutSubMessage("大宴已经无免费次数!");
                    return true;
                }
                return false;
            }, () => Dm.Delay(1000));

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
    }
}
