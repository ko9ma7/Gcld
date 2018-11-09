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
    public class AutoLogin : TaskBase
    {
        public AutoLogin(TaskContext context) : base(context)
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
                new TaskStep() {Name="自动登陆",Order=1,RunFunc=RunStep1 }

             };
            return steps;
        }
      

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;

            //Delegater.WaitTrue(() =>
            //{
            //    if(Dm.IsExistPic(0,0,0,0,""))


            //    return true;
            //},()=>dm.Delay(1000));


            return TaskResult.Finished;
        }
    }
}
