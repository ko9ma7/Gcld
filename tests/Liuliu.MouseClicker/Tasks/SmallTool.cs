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
    public class SmallTool : TaskBase
    {
        public SmallTool(TaskContext context) : base(context)
        {
        
        }

        protected override int GetStepIndex(TaskContext context)
        {
            try
            {
                if (context.Settings.IsAutoWeapon)
                {
                    return 1;
                }
            } catch{ }
            try
            {
                if (context.Settings.IsAutoClear)
                {
                    return 3;
                }
            }
            catch { }
            try
            {
                if (context.Settings.IsAutoBuilding)
                {
                    return 2;
                }
            }
            catch { }
            return 1;
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动兵器",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="自动建筑",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="自动洗练",Order=3,RunFunc=RunStep3 }
             };
            return steps;
        }
        private TaskResult RunStep3(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;

            Delegater.WaitTrue(() =>
            {
                string points = Dm.FindPicEx(98, 120, 556, 513, @"\bmp\星星3.bmp", "202020", 0.8, 0);
                Debug.WriteLine(points);
                if (points == "")
                {
                    return true;
                }
                string[] t = points.Split('|');

                foreach (var item in t)
                {
                    string[] p = item.Split(',');
                    Dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                    Dm.Delay(1000);
                    if (Dm.IsExistPic(707, 382, 734, 404, @"\bmp\星星1.bmp"))
                    {
                        if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp"))
                        {
                            continue;
                        }
                        while (true)
                        {

                            Dm.MoveToClick(631, 448);
                            Dm.Delay(500);
                            if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp"))
                            {
                                Dm.Delay(1000);
                                break;
                            }
                        }
                    }  
                }
                Dm.Swipe(515, 438, 515, 220, 50);

                return false;
            });
            return TaskResult.Finished;
        }
        private TaskResult RunStep2(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            if(dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") && 
               dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") &&
               dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp"))
            {
                role.OutSubMessage("在建筑中...");
            }
            else
            {
                role.GoToMap("主城");
                dm.MoveToClick(317, 460);
                dm.Delay(2000);
            }
            string a, b;
            Delegater.WaitTrue(() =>
            {
               a=dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                //Dm.MoveToClick(681, 281);
                //dm.FindPicAndClick(546, 168, 868, 382, @"\bmp\升级.bmp");
                //dm.Delay(1000);
                if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤2.bmp"))
                {
                    dm.MoveToClick(152, 429);
                    dm.Delay(5000);
                }
                dm.Delay(500);
                b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                if(a!=b)
                {
                    dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                }
                return false;
            });
            return TaskResult.Finished;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            role.OutMessage("打开兵器界面");

            Delegater.WaitTrue(() =>
            {
                int a = Dm.GetColorNum(113, 83, 173, 135, "e25858 - 202020", 0.9);
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                return a > 10;
            }, () =>
            {
                Dm.MoveToClick(409, 181);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int b = Dm.GetColorNum(104, 229, 187, 286, "e25858 - 202020", 0.9);
                return b > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 326);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int c = Dm.GetColorNum(110, 374, 181, 433, "e25858 - 202020", 0.9);
                return c > 10;
            }, () =>
            {
                Dm.MoveToClick(408, 471);
                Dm.Delay(200);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int d = Dm.GetColorNum(478, 86, 559, 144, "e25858 - 202020", 0.9);
                return d > 10;
            }, () =>
            {
                Dm.MoveToClick(790, 182);
                Dm.Delay(200);
            });
            int i = 0;
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
                int e = Dm.GetColorNum(500, 249, 533, 269, "c2d3af-202020", 0.9);
                if(e<10)
                {
                    Dm.Delay(2000);
                    if(Dm.GetColorNum(500, 249, 533, 269, "c2d3af-202020", 0.9)<10)
                    {
                        return true;
                    }
                }
                return false;
            }, () =>
            {
                Dm.MoveToClick(787, 326);
                Dm.Delay(300);
            });
            Delegater.WaitTrue(() =>
            {
                if (Dm.GetColorNum(245, 166, 304, 194, "e40201 -202020", 0.9) > 10)
                    return true;
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
