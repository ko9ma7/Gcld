using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Tasks
{
    public class LingqujunziTask : TaskBase
    {
        public LingqujunziTask(TaskContext context) : base(context)
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
                new TaskStep() {Name="打开地图",Order=1,RunFunc=RunStep1 }
             };
            return steps;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            IRole role = context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage(dm.GetHashCode().ToString());
            role.OutMessage(Thread.CurrentThread.ManagedThreadId.ToString());
            dm.MoveToClick(670, 50);
            dm.Delay(1000);
            Debug.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            dm.SetPath(AppDomain.CurrentDomain.BaseDirectory);
            bool m= dm.SetDict(0,"dict.txt");
            bool r= dm.UseDict(0);
           
            int intX, intY;
            for (int i = 0; i < 24; i++)
            {
              
                dm.FindStr(59, 182, 117, 211, "军资奖励", "44.34.66-10.10.30", 1.0, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    dm.MoveToClick(114, 306);
                    dm.Delay(50);
                }else
                {
                    role.OutMessage("找不到");
                  bool c=  dm.Capture(0, 0, 200, 200,"temp.bmp");

                }
            }
            


            return TaskResult.Success;
        }
    }
}
