using Liuliu.ScriptEngine;
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
    public class CaochuanjiejianTask : TaskBase
    {
        public CaochuanjiejianTask(TaskContext context) : base(context)
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
                new TaskStep() {Name="",Order=1,RunFunc=RunStep1 }
             };
            return steps;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            IRole role = context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开活动界面");
            Debug.WriteLine("打开活动界面1111");
            return TaskResult.Success;
        }
    }
}
