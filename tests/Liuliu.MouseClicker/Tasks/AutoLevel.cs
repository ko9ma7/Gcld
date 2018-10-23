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
    public class AutoLevel : TaskBase
    {
        public AutoLevel(TaskContext context) : base(context)
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
                new TaskStep() {Name="自动升级",Order=1,RunFunc=RunStep1 }

             };
            return steps;
        }
      

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;

           // role.GoToMap("世界");
           // role.CloseWindow();
            dm.SetDict(1, "maintask.txt");
            dm.UseDict(1);
            //int level = role.Level;
            while (true)
            {
                string taskName = dm.Ocr(5, 122, 114, 179, "C8C8A4-37372D",0.9);
                switch (taskName)
                {
                    case "欢迎":
                        ClickXiaoQian();
                        break;
                    case "民居1":
                        dm.MoveToClick(481, 114);
                        dm.FindPicAndClick(389, 58, 687, 224, @"\bmp\升级.bmp");
                        dm.Delay(1000);
                        dm.FindPicAndClick(389, 58, 687, 224, @"\bmp\加速锤.bmp");
                        dm.Delay(1000);
                        break;
                    case "民居2":
                        dm.MoveToClick(908, 119);
                        break;
                    case "大名":
                        ClickXiaoQian();
                        if (dm.IsExistPic(379, 13, 567, 62,@"\bmp\创建.bmp"))
                        {
                            Debug.WriteLine("请输入角色名！");
                        }
                        break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    //case "":
                    //    break;
                    default:
                        ClickXiaoQian();
                        break;
                }
                dm.Delay(2000);
            }
            dm.UseDict(0);
            return TaskResult.Finished;
            
        }

        public bool ClickXiaoQian()
        {
           return Delegater.WaitTrue(() => {
                if (!Dm.FindPicAndClick(56, 240, 276, 469, @"\bmp\小倩.bmp"))
                {
                    return true;
                }
                Dm.Delay(1000);
                return false;
            }, () => Dm.Delay(1000));
        }
    }
}
