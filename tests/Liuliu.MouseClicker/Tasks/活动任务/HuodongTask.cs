﻿using Liuliu.ScriptEngine;
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
        private string activities = "";
        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="大宴群雄",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="宝石矿脉",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="万邦来朝",Order=2,RunFunc=RunStep3 },
                new TaskStep() {Name="宝石矿脉",Order=2,RunFunc=RunStep4 }
             };
            return steps;
        }

        private TaskResult RunStep4(TaskContext context)
        {
            Role role = (Role)context.Role;



            if (Repetitions >= 9)
            {
                return TaskResult.Finished;
            }
            else
            {
                role.ChangeRole();
                Dm.Delay(5000);
                activities = "";
                string points = Dm.FindPicEx(286, 37, 875, 284, @"\bmp\活动2.bmp", "202020", 0.8, 0);
                Debug.WriteLine(points);

                if (points == "")
                {
                    role.CloseWindow();
                    return new TaskResult(TaskResultType.Fail, "无法点击活动!");
                }
                string[] t = points.Split('|');

                foreach (var item in t)
                {
                    string[] p = item.Split(',');
                    Dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                    Dm.Delay(1000);
                    string ocr = Dm.Ocr(75, 2, 909, 70, "45.34.60-5.5.20|60.18.75-5.5.25", 0.9);
                    Debug.WriteLine(ocr);
                    activities += ocr;
                }
                role.CloseWindow();
                return TaskResult.Success;
            }
        }

        private TaskResult RunStep3(TaskContext context)
        {
            Role role = (Role)context.Role;
            if (!activities.Contains("万邦来朝"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(() => role.OpenActivityBoard("万邦来朝"),
                             () => Dm.IsExistPic(249, 78, 799, 145, @"\bmp\万邦.bmp"),
                             () => Dm.Delay(1000));

            for (int i = 0; i < 20; i++)
            {
                if(Dm.IsExistPic(668, 466, 756, 516,@"\bmp\万邦_金币.bmp"))
                {
                    Dm.MoveToClick(472, 323);
                    Dm.Delay(1000);
                    break;
                }
                Dm.MoveToClick(780, 493);//点击发出请帖
                Dm.Delay(1000);
            }
            role.CloseWindow();
            return TaskResult.Success;
         
        }

        private TaskResult RunStep2(TaskContext context)
        {
            if (!activities.Contains("宝石矿脉"))
            {
                return TaskResult.Jump;
            }
            return TaskResult.Success;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开活动界面");
            if (!activities.Contains("大宴群雄"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(()=> role.OpenActivityBoard("大宴群雄"),
                               ()=> Dm.IsExistPic(266, 83, 692, 160, @"\bmp\大宴群雄.bmp"),
                               ()=> Dm.Delay(1000));
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
            return TaskResult.Success;
         
        }

    }




}
