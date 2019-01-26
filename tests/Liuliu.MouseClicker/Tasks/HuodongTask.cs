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
        protected override void OnStopping(TaskContext context)
        {
            Role role = (Role)context.Role;
            role.CloseWindow();
        }
        protected override void OnStarting(TaskContext context)
        {
            Role role = (Role)context.Role;
            activities = "";
            string points = Dm.FindPicEx(286, 37, 875, 284, @"\bmp\活动2.bmp", "202020", 0.8, 0);
            Debug.WriteLine(points);

            if (points == "")
            {
                role.CloseWindow();
                return;
            }
            string[] t = points.Split('|');

            foreach (var item in t)
            {
                string[] p = item.Split(',');
                Dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                Dm.Delay(1000);
                if(Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"))
                {
                    Dm.Delay(2000);
                }
                string ocr = Dm.Ocr(75, 2, 909, 70, "45.34.60-5.5.20|60.18.75-5.5.25", 0.8);
                Debug.WriteLine(ocr);
                activities += ocr;
            }
            role.OutSubMessage(activities);
           // role.CloseWindow();
        }

        
        private string activities = "";
        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="大宴群雄",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="宝石矿脉",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="万邦来朝",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="古城探宝",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="海岛寻宝",Order=5,RunFunc=RunStep5 },
                new TaskStep() {Name="天降神剑",Order=6,RunFunc=RunStep6 },
                new TaskStep() {Name="草船借箭",Order=7,RunFunc=RunStep7 },
             };
            return steps;
        }

        private TaskResult RunStep7(TaskContext context)
        {
            Role role = (Role)context.Role;
            if (!activities.Contains("草船借箭"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(() => role.OpenActivityBoard("草船借箭"),
                             () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\草船.bmp"),
                             () => Dm.Delay(1000));
           
                 Delegater.WaitTrue(() => {
                     if (Dm.IsExistPic(360, 363, 416, 408, @"\bmp\草船金币再来一次.bmp"))
                         return true;
                      if (Dm.IsExistPic(706, 159, 790, 214, @"\bmp\草船金币2.bmp"))
                         return true;
                     if (Dm.IsExistPic(718, 157, 838, 235, @"\bmp\草船剩余.bmp")||Dm.IsExistPic(378, 362, 507, 428, @"\bmp\草船再来一次.bmp"))
                     {
                         if(Dm.IsExistPic(378, 362, 507, 428, @"\bmp\草船再来一次.bmp"))
                             Dm.FindPicAndClick(378, 362, 507, 428, @"\bmp\草船再来一次.bmp");
                         else
                             Dm.MoveToClick(778, 231);
                         while (!Dm.IsExistPic(345, 200, 523, 310, @"\bmp\草船中游.bmp"))
                         {
                             Dm.Delay(500);
                         }
                         while(true)
                         {
                             if(Dm.IsExistPic(345, 200, 523, 310, @"\bmp\草船中游.bmp"))
                             {
                                 Random rd = new Random();
                                 switch (rd.Next(1, 4))
                                 {
                                     case 1:
                                         role.OutSubMessage("随机点击:上游!");
                                         Dm.MoveToClick(673, 231);
                                         break;
                                     case 2:
                                         role.OutSubMessage("随机点击:中游!");
                                         Dm.MoveToClick(498, 308);
                                         break;
                                     case 3:
                                         role.OutSubMessage("随机点击:下游!");
                                         Dm.MoveToClick(329, 397);
                                         break;
                                     default:
                                         role.OutSubMessage("随机点击生成错误!");
                                         break;
                                 }
                                 while (!Dm.IsExistPic(378, 362, 507, 428, @"\bmp\草船再来一次.bmp"))
                                 {
                                     Dm.Delay(500);
                                 }
                             }
                             if (!Dm.IsExistPic(360, 363, 416, 408, @"\bmp\草船金币再来一次.bmp"))
                                 Dm.FindPicAndClick(378, 362, 507, 428, @"\bmp\草船再来一次.bmp");
                             else
                                 break;
                             if (Dm.FindPicAndClick(485, 323, 618, 399, @"\bmp\取消.bmp"))
                                 break;
                         }
                         
                         return true;
                     }
                     return false;
                 }, () => Dm.Delay(1000));
            Dm.FindPicAndClick(581, 360, 719, 428, @"\bmp\草船返回选船.bmp");
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep6(TaskContext context)
        {
            Role role = (Role)context.Role;
            if (!activities.Contains("天降神剑"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(() => role.OpenActivityBoard("天降神剑"),
                 () => Dm.IsExistPic(395, 81, 535, 151, @"\bmp\神剑.bmp"),
                 () => Dm.Delay(1000));
            if (Dm.IsExistPic(493, 309, 647, 390, @"\bmp\败.bmp") && !Dm.IsExistPic(429, 431, 543, 485, @"\bmp\神剑继续.bmp"))
            {
                role.OutSubMessage("神剑正在冷却中!");
                role.CloseWindow();
                return TaskResult.Success;
            }
            while (true)
            {
               if(Dm.FindPicAndClick(429, 431, 543, 485, @"\bmp\神剑继续.bmp"))
                {
                    Dm.Delay(1500);
                }
                if (Dm.IsExistPic(171, 313, 312, 432, @"\bmp\点击斩杀.bmp",0.7))
                {
                    int count = 0;
                    Delegater.WaitTrue(() => 
                    {
                        Dm.MoveToClick(241, 376);
                        if (Dm.GetColorNum(201, 316, 288, 355, "71dc37-303030", 0.9) > 100&&count>10)
                        {
                            Dm.Delay(1000);
                            if(Dm.GetColorNum(201, 316, 288, 355, "71dc37-303030", 0.9) > 100)
                              return true;
                        }
                        count++;
                        return false;
                    },()=> Dm.Delay(100));
                }
                if (Dm.IsExistPic(408, 355, 566, 433, @"\bmp\点击斩杀.bmp", 0.7))
                {
                    int count = 0;
                    Delegater.WaitTrue(() =>
                    {
                        Dm.MoveToClick(484, 373);
                        if (Dm.GetColorNum(431, 309, 536, 349, "71dc37-303030", 0.9) > 100 && count > 10)
                        {
                            Dm.Delay(1000);
                            if(Dm.GetColorNum(431, 309, 536, 349, "71dc37-303030", 0.9) > 100)
                              return true;
                        }
                        count++;
                        return false;
                    }, () => Dm.Delay(100));
                }
                if (Dm.IsExistPic(655, 354, 786, 430, @"\bmp\点击斩杀.bmp", 0.7))
                {
                    int count = 0;
                    Delegater.WaitTrue(() =>
                    {
                        Dm.MoveToClick(720, 381);
                        if (Dm.GetColorNum(672, 298, 768, 344, "71dc37-303030", 0.9) > 100&&count>10)
                        {
                            Dm.Delay(1000);
                            if (Dm.GetColorNum(672, 298, 768, 344, "71dc37-303030", 0.9) > 100)
                                return true;
                        }
                        count++;
                        return false;
                    }, () => Dm.Delay(100));
                }
                if(!Dm.IsExistPic(171, 313, 312, 432, @"\bmp\点击斩杀.bmp", 0.7)&&
                   !Dm.IsExistPic(408, 355, 566, 433, @"\bmp\点击斩杀.bmp", 0.7)&&
                   !Dm.IsExistPic(655, 354, 786, 430, @"\bmp\点击斩杀.bmp", 0.7))
                {
                    break;
                }
            }
            Delegater.WaitTrue(()=>
            {
                if (Dm.FindPicAndClick(370, 454, 583, 536, @"\bmp\挑战.bmp|\bmp\挑战2.bmp"))
                {
                    int count = 0;
                    while (true)
                    {
                        count++;
                        Dm.MoveToClick(477, 407);
                        Dm.Delay(500);
                        if(Dm.CmpColor(426, 300, "9c1912-202020", 0.9))
                        {
                            Dm.Delay(1000);
                            if(!Dm.CmpColor(426, 300, "9c1912-202020", 0.9))
                            {
                                break;
                            }
                        }
                        if (count > 15)
                            break;
                    }
                    while (Dm.FindColorAndClick(139, 263, 831, 484, "fbd41b-202020"))
                    {
                        Dm.Delay(500);
                        if (Dm.IsExistPic(493, 309, 647, 390, @"\bmp\败.bmp"))
                            return true;
                    }
                    if (Dm.IsExistPic(493, 309, 647, 390, @"\bmp\败.bmp"))
                        return true;
                }
                return false;
            },()=>Dm.Delay(100),5);
            role.CloseWindow();
            return TaskResult.Success;
        }

        private TaskResult RunStep5(TaskContext context)
        {
            Role role = (Role)context.Role;
            if (!activities.Contains("海岛寻宝"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(() => role.OpenActivityBoard("海岛寻宝"),
                             () => Dm.IsExistPic(366, 75, 481, 131, @"\bmp\海岛.bmp"),
                             () => Dm.Delay(1000));

            Delegater.WaitTrue(() => Dm.IsExistPic(259, 360, 411, 433, @"\bmp\海岛免费.bmp")|| Dm.IsExistPic(273, 366, 360, 423, @"\bmp\海岛金币.bmp"),
                             () => Dm.MoveToClick(147, 83));
            Delegater.WaitTrue(() => {
                                if(Dm.FindPicAndClick(259, 360, 411, 433, @"\bmp\海岛免费.bmp"))
                                {
                                    Dm.Delay(3000);  
                                }
                                if (Dm.IsExistPic(273, 366, 360, 423, @"\bmp\海岛金币.bmp"))
                                    return true;
                                return false;
                                },() => Dm.Delay(1000));

            role.CloseWindow();
            return TaskResult.Success;

        }

        private TaskResult RunStep4(TaskContext context)
        {
            Role role = (Role)context.Role;
            if (!activities.Contains("探宝寻踪"))
            {
                return TaskResult.Jump;
            }
            //return TaskResult.Jump;
            Delegater.WaitTrue(() => role.OpenActivityBoard("探宝寻踪"),
                             () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                             () => Dm.Delay(1000));
            //图一
            if(Dm.IsExistPic(142,415,316,496, @"\bmp\古城探索.bmp")&& !Dm.IsExistPic(142, 415, 316, 496, @"\bmp\已探索.bmp"))
            {
                role.OutSubMessage("开始探索第一图...");
                Delegater.WaitTrue(() => Dm.FindPicAndClick(140, 380, 824, 512, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
                #region 模拟
               
                bool isMove且末西 = false, isMove且末北 = false, isMove且末东=false,isMove车师南 = false,isMove楼兰古城=false;
                Delegater.WaitTrue(() =>
                {
                    //存在古城金币则没有次数,并且没有可走,退出
                    if (Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp")&&!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                       return Delegater.WaitTrue(() => Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                           () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                                           () => Dm.Delay(1000));
                    }

                    //还可走,已经投掷骰子
                    if (Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                        if (isMove且末西 == false)
                        {
                          
                            MovePanel("左下");
                            if (Dm.IsExistPic(87,63,581,476, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(183, 135);
                                MovePanel("左下");
                            }
                            else
                            {
                                role.OutSubMessage("楼兰入口-且末,未找到马车,可能已经走过或马车无法识别.");
                                isMove且末西 = true;
                            }
                           
                            if (Dm.IsExistPic(101, 78, 261, 193, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在且末西.");
                                isMove且末西 = true; 
                            }
                            
                            return false;
                        }
                        
                        if (isMove且末北 == false)
                        {
                            MovePanel("左上");
                            Dm.Delay(1000);
                            if (Dm.IsExistPic(69,163,407,494, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(308, 251);//点击且末北
                                MovePanel("左上");
                            }
                            else
                            {
                                role.OutSubMessage("且末西,未找到马车,可能已经走过或马车无法识别.");
                                isMove且末北 = true;
                            }

                            if (Dm.IsExistPic(225, 191, 390, 312, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在且末北.");
                                isMove且末北 = true;
                            }
                            return false;
                        }
                        
                        if (isMove且末东 == false)
                        {
                            MovePanel("左上");
                            if (Dm.IsExistPic(198,179,411,328, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(686,324);//点击且末东
                                MovePanel("左上");
                            }
                            else
                            {
                                role.OutSubMessage("且末北,未找到马车,可能已经走过或马车无法识别.");
                                isMove且末东 = true;
                            }
                            if (Dm.IsExistPic(589,249,780,394, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在且末东.");
                                isMove且末东 = true;
                            }
                            return false;
                        }
                        if (isMove车师南 == false)
                        {
                                MovePanel("右上");
                                if (Dm.IsExistPic(152,244,361,403, @"\bmp\马车.bmp"))
                                {
                                    Dm.MoveToClick(515, 372);//点击车师南
                                    MovePanel("右上");
                                }
                                else
                                {
                                    role.OutSubMessage("且末东,未找到马车,可能已经走过或马车无法识别.");
                                    isMove车师南 = true;
                                }
                                if (Dm.IsExistPic(424, 305, 592, 434, @"\bmp\马车.bmp"))
                                {
                                    role.OutSubMessage("马车在车师南.");
                                    isMove车师南 = true;
                                }
                            return false;
                        }
                        if (isMove楼兰古城 == false)
                        {
                            MovePanel("右上");
                            if(Dm.FindPicAndClick(617,105,771,203, @"\bmp\楼兰古城.bmp",30,-30))
                            {
                                Dm.Delay(1000);
                            }
                            return false;
                        }
                    }
                    if (Dm.IsExistPic(409, 231, 521, 332, @"\bmp\古城宝箱.bmp", 0.8))
                    {
                        role.OutSubMessage("马车在楼兰古城.");
                        isMove楼兰古城 = true;
                        return Delegater.WaitTrue(() => Dm.MoveToClick(461, 260),
                            () => Dm.IsExistPic(414, 420, 566, 492, @"\bmp\古城探索.bmp"),
                            () => Dm.Delay(1000));
                    }
                    //投掷骰子
                    if (!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp") &&
                        !Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp")&& 
                        Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"))
                    {
                        Delegater.WaitTrue(() => Dm.MoveToClick(908, 478),
                                           () => Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp")|| Dm.IsExistPic(414, 420, 566, 492, @"\bmp\古城探索.bmp"),
                                           () => Dm.Delay(1000), 2000);
                    }
                    if (Dm.IsExistPic(414, 420, 566, 492, @"\bmp\古城探索.bmp"))
                    {
                        role.OutSubMessage("第一图已经走完!");
                        isMove楼兰古城 = true;
                        return true;
                    }
                    return false;
                }, () => Dm.Delay(1000));
                #endregion
            }
            Dm.Delay(2000);
            //图二
            if (Dm.IsExistPic(414, 420, 566, 492, @"\bmp\古城探索.bmp") && !Dm.IsExistPic(414, 420, 566, 492, @"\bmp\已探索.bmp"))
            {
                role.OutSubMessage("开始探索第二图...");
                Delegater.WaitTrue(() => Dm.FindPicAndClick(414, 420, 566, 492, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
                bool isMove渊泉西 = false, isMove伊吾东 = false, isMove盐泽 = false, isMove敦煌古城 = false;
                Delegater.WaitTrue(() =>
                {
                    //存在古城金币则没有次数,并且没有可走,退出
                    if (Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp") && !Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                        return Delegater.WaitTrue(() => Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                            () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                                            () => Dm.Delay(1000));
                    }

                    //还可走,已经投掷骰子
                    if (Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                        if (isMove渊泉西 == false)
                        {

                            MovePanel("右上");
                            if (Dm.IsExistPic(657,87,854,534, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(504, 392); //点击渊泉西
                                MovePanel("右上");
                                Dm.Delay(500);
                            }
                            else
                            {
                                role.OutSubMessage("敦煌入口-渊泉-渊泉南,未找到马车,可能已经走过或马车无法识别.");
                                isMove渊泉西 = true;
                            }

                            if (Dm.IsExistPic(409,313,585,465, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在渊泉西.");
                                isMove渊泉西 = true;
                            }

                            return false;
                        }

                        if (isMove伊吾东 == false)
                        {
                            MovePanel("右上");
                            if (Dm.IsExistPic(271,247,585,445, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(572,202);//点击伊吾东
                                MovePanel("右上");
                            }
                            else
                            {
                                role.OutSubMessage("渊泉-伊吾南,未找到马车,可能已经走过或马车无法识别.");
                                isMove伊吾东 = true;
                            }

                            if (Dm.IsExistPic(481,120,650,265, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在伊吾东.");
                                isMove伊吾东 = true;
                            }
                            return false;
                        }

                        if (isMove盐泽 == false)
                        {
                            MovePanel("右上");
                            if (Dm.IsExistPic(255,124,638,350, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(134,339);//点击盐泽
                                MovePanel("右上");
                            }
                            else
                            {
                                role.OutSubMessage("伊吾东-伊吾南,未找到马车,可能已经走过或马车无法识别.");
                                isMove盐泽 = true;
                            }
                            if (Dm.IsExistPic(53,267,203,393, @"\bmp\马车.bmp"))
                            {
                                role.OutSubMessage("马车在盐泽.");
                                isMove盐泽 = true;
                            }
                            return false;
                        }
                      
                        if (isMove敦煌古城 == false)
                        {
                            MovePanel("左下");
                            if (Dm.FindPicAndClick(54,95,253,274, @"\bmp\敦煌古城.bmp", 30, -30))
                            {
                                Dm.Delay(1000);
                            }
                            return false;
                        }
                    }
                    if (Dm.IsExistPic(409, 231, 521, 332, @"\bmp\古城宝箱.bmp", 0.8))
                    {
                        role.OutSubMessage("马车在敦煌古城.");
                        isMove敦煌古城 = true;
                        return Delegater.WaitTrue(() => Dm.MoveToClick(461, 260),
                              () => Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp"),
                              () => Dm.Delay(1000));
                    }
                    //投掷骰子
                    if (!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp") &&
                        !Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp") &&
                        Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"))
                    {
                        Delegater.WaitTrue(() => Dm.MoveToClick(908, 478),
                                           () => Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp")|| Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp"),
                                           () => Dm.Delay(1000), 2000);
                    }
                    if (Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp"))
                    {
                        role.OutSubMessage("第二图已经走完!");
                        isMove敦煌古城 = true;
                        return true;
                    }
                    return false;
                }, () => Dm.Delay(1000));
            }
            Dm.Delay(2000);
            //图三
            if (Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp") && !Dm.IsExistPic(659, 411, 822, 495, @"\bmp\已探索.bmp"))
            {
                role.OutSubMessage("开始探索第三图...");
                Delegater.WaitTrue(() => Dm.FindPicAndClick(659, 411, 822, 495, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
                bool isMove伍塔木 = false;
                Delegater.WaitTrue(() =>
                {
                    //存在古城金币则没有次数,并且没有可走,退出
                    if (Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp") && !Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                        return Delegater.WaitTrue(() => Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                            () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                                            () => Dm.Delay(1000));
                    }


                    //还可走,已经投掷骰子
                    if (Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"))
                    {
                        if (isMove伍塔木 == false)
                        {

                            MovePanel("右下");
                            Dm.Delay(500);
                            if (!Dm.IsExistPic(81, 271, 309, 451, @"\bmp\马车.bmp"))
                            {
                                Dm.MoveToClick(193, 360); //点击伍塔木
                                MovePanel("右下");
                                Dm.Delay(500);
                            }
                            else
                            {
                                isMove伍塔木 = true;
                                return Delegater.WaitTrue(() => Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                            () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                                            () => Dm.Delay(1000));
                            }
                            return false;
                        }
                    }
                   
                    //投掷骰子
                    if (!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp") &&
                        !Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp") &&
                        Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"))
                    {
                        Delegater.WaitTrue(() => Dm.MoveToClick(908, 478),
                                           () => Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp") || Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp"),
                                           () => Dm.Delay(1000), 2000);
                    }
                    return false;
                }, () => Dm.Delay(1000));
            }

            role.CloseWindow();
            return TaskResult.Success;
            
        }
        /// <summary>
        /// 移动面板:
        /// </summary>
        /// <param name="direct">左下,左上,右下,右上</param>
        private void MovePanel(string direct)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (direct)
            {
                case "左下":
                    Dm.Swipe(304, 50, 666, 50,30,60);//向右拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 418, 80, 115, 30, 60);//向上拉
                    break;
                case "左上":
                    Dm.Swipe(304, 50, 666, 50, 30, 60);//向右拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 115, 80, 418, 30, 60);//向下拉
                    break;
                case "右下":
                    Dm.Swipe(666, 50, 304, 50, 30, 60);//向左拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 418, 80, 115, 30, 60);//向上拉
                    break;
                case "右上":
                    Dm.Swipe(666, 50, 304, 50, 30, 60);//向左拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 115, 80, 418, 30, 60);//向下拉
                    break;
                default:
                    break;
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
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
            Role role = (Role)context.Role;
            if (!activities.Contains("宝石矿脉"))
            {
                return TaskResult.Jump;
            }
            Delegater.WaitTrue(() => role.OpenActivityBoard("宝石矿脉"),
                            () => Dm.IsExistPic(357, 100, 595, 169, @"\bmp\宝石.bmp"),
                            () => Dm.Delay(1000));
      
          
             Delegater.WaitTrue(() =>
             {
                 //是否存在金币颜色
                 if(Dm.GetColorNum(135,451,183,490, "C7B43D-384B3B", 1.0)>10)
                 {
                     if (Dm.FindPicAndClick(568, 452, 742, 521, @"\bmp\前往下层.bmp"))
                     {
                         if (Dm.IsExistPic(462, 195, 568, 241, @"\bmp\进入下层.bmp",0.7))
                         {
                             Dm.FindPicAndClick(305, 230, 655, 458, @"\bmp\确定.bmp");
                         }
                     }
                     else
                         return true;
                 }
                 //是否存在数字
               if(Dm.GetColorNum(135, 451, 183, 490, "C0C0C0-3C3C3C", 1.0)>6)
                 {
                     int intX, intY;
                     Dm.FindPic(95, 231, 867, 515, @"\bmp\星星2.bmp", "202020", 0.9, 0, out intX, out intY);
                     if (intX > 0 && intY > 0)
                     {
                         Delegater.WaitTrue(() =>
                         {
                             if (Dm.IsExistPic(intX - 10, intY - 10, intX + 120, intY + 50, @"\bmp\星星1.bmp"))
                             {
                                 Dm.MoveToClick(intX + 37, intY - 20);
                                 Dm.Delay(200);
                                 Dm.MoveToClick(intX + 37, intY - 20);
                                 Dm.Delay(500);
                             }
                             else
                             {
                                 return true;
                             }
                             if (Dm.GetColorNum(135, 451, 183, 490, "C7B43D-384B3B", 1.0) > 10)
                             {
                                 return true;
                             }
                             return false;
                         },()=>Dm.Delay(1000));
                     }
                     else
                     {
                         Dm.FindPic(95, 231, 867, 515, @"\bmp\星星1.bmp", "202020", 0.9, 0, out intX, out intY);
                         if (intX > 0 && intY > 0)
                         {
                             Delegater.WaitTrue(() =>
                             {
                                 if (Dm.GetColorNum(135, 451, 183, 490, "C7B43D-384B3B", 1.0) > 10)
                                 {
                                     return true;
                                 }
                                 if (Dm.IsExistPic(intX - 10, intY - 10, intX + 120, intY + 50, @"\bmp\星星1.bmp"))
                                 {
                                     Dm.MoveToClick(intX + 37, intY - 20);
                                     Dm.Delay(200);
                                     Dm.MoveToClick(intX + 37, intY - 20);
                                     Dm.Delay(500);
                                 }
                                 else
                                 {
                                     return true;
                                 }
                                 return false;
                             }, () => Dm.Delay(1000));
                         }  
                     } 
                 }
                 Dm.MoveToClick(120, 253);
                 Dm.Delay(500);
                 return false;
             },() => Dm.Delay(1000));

            role.CloseWindow();
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
