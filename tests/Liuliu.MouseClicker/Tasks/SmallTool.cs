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
           
            return 1;
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动兵器",Order=1,RunFunc=RunStep1 }
             };
            return steps;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开兵器界面");

            Delegater.WaitTrue(() =>
            {
                int a = Dm.GetColorNum(113, 83, 173, 135, "e25858 - 202020", 0.9);
                return a > 10;
            }, () =>
            {
                Dm.MoveToClick(409, 181);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                int b = Dm.GetColorNum(104, 229, 187, 286, "e25858 - 202020", 0.9);
                return b > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 326);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                int c = Dm.GetColorNum(110, 374, 181, 433, "e25858 - 202020", 0.9);
                return c > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 471);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                int d = Dm.GetColorNum(478, 86, 559, 144, "e25858 - 202020", 0.9);
                return d > 10;
            }, () =>
            {
                Dm.MoveToClick(790, 182);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                int e = Dm.GetColorNum(500, 249, 533, 269, "e25858-202020", 0.9);
                return e > 10;
            }, () =>
            {
                Dm.MoveToClick(787, 326);
                Dm.Delay(300);
            });
            Delegater.WaitTrue(() =>
            {
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
