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
                string ocr = Dm.Ocr(75, 2, 909, 70, "45.34.60-5.5.20|60.18.75-5.5.25", 0.9);
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
            if (Dm.IsExistPic(493, 309, 647, 390, @"\bmp\败.bmp"))
            {
                role.OutSubMessage("神剑正在冷却中!");
                role.CloseWindow();
                return TaskResult.Success;
            }
                while (true)
            {
               if(Dm.FindPicAndClick(193, 371, 791, 440, @"\bmp\点击斩杀.bmp|\bmp\点击斩杀1.bmp|\bmp\点击斩杀3.bmp", 30,-20))
                {
                    Dm.Delay(800);
                    if (Dm.GetColorNum(180, 443, 312, 480, "66C031 -0B1C06", 0.9) > 20)
                        Dm.MoveToClick(245, 380);
                    if (Dm.GetColorNum(417, 449, 547, 478, "66C031 -0B1C06", 0.9) > 20)
                        Dm.MoveToClick(483, 379);
                    if (Dm.GetColorNum(643, 452, 795, 478, "66C031 -0B1C06", 0.9) > 20)
                        Dm.MoveToClick(725, 374);
                }
               else
                {
                    Dm.Delay(2000);
                    if (!Dm.FindPicAndClick(193, 371, 791, 440, @"\bmp\点击斩杀.bmp|\bmp\点击斩杀1.bmp|\bmp\点击斩杀3.bmp", 30, -20))
                    {
                       while(true)
                        {
                            Dm.FindPicAndClick(157, 431, 819, 497, @"\bmp\领取buff.bmp", 3, -70);
                            if (Dm.GetColorNum(180, 443, 312, 480, "66C031 -0B1C06", 0.9) > 20)
                                Dm.MoveToClick(245, 380);
                            if (Dm.GetColorNum(417, 449, 547, 478, "66C031 -0B1C06", 0.9) > 20)
                                Dm.MoveToClick(483, 379);
                            if (Dm.GetColorNum(643, 452, 795, 478, "66C031 -0B1C06", 0.9) > 20)
                                Dm.MoveToClick(725, 374);
                            if (Dm.GetColorNum(180, 443, 312, 480, "66C031 -0B1C06", 0.9) < 10 && Dm.GetColorNum(417, 449, 547, 478, "66C031 -0B1C06", 0.9) < 10 && Dm.GetColorNum(643, 452, 795, 478, "66C031 -0B1C06", 0.9) < 10)
                                break;
                            Dm.Delay(1000);
                        }
                        Dm.Delay(1000);
                        break;
                    }
                }

            }
            Delegater.WaitTrue(()=>
            {
                if (Dm.FindPicAndClick(370, 454, 583, 536, @"\bmp\挑战.bmp|\bmp\挑战2.bmp"))
                {
                    while (Dm.CmpColor(426, 300, "9c1912-202020", 0.9))
                    {
                        Dm.MoveToClick(477, 407);
                        Dm.Delay(500);
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

            Delegater.WaitTrue(() => role.OpenActivityBoard("探宝寻踪"),
                             () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                             () => Dm.Delay(1000));
            //图一
            if(Dm.IsExistPic(142,415,316,496, @"\bmp\古城探索.bmp"))
            {
                Delegater.WaitTrue(() => Dm.FindPicAndClick(140, 380, 824, 512, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
                bool isMove且末西 = false, isMove且末北 = false,isMove车师南=false,isMove楼兰古城=false;
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
                            Dm.Delay(1000);
                            if (Dm.IsExistPic(87,63,581,476, @"\bmp\马车.bmp", 0.6))
                            {
                                Dm.MoveToClick(183, 135);
                                Dm.Delay(2000);
                                MovePanel("左下");
                            }
                            else
                            {
                                role.OutSubMessage("未找到马车,可能已经走过或马车无法识别.");
                                isMove且末西 = true;
                            }
                            if (Dm.IsExistPic(101, 78, 261, 193, @"\bmp\马车.bmp", 0.6))
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
                            if (Dm.IsExistPic(69,163,407,494, @"\bmp\马车.bmp", 0.6))
                            {
                                Dm.MoveToClick(308, 251);
                                Dm.Delay(2000);
                                MovePanel("左上");
                            }
                            else
                            {
                                role.OutSubMessage("未找到马车,可能已经走过或马车无法识别.");
                                isMove且末北 = true;
                            }

                            if (Dm.IsExistPic(225, 191, 390, 312, @"\bmp\马车.bmp", 0.6))
                            {
                                role.OutSubMessage("马车在且末北.");
                                isMove且末北 = true;
                            }
                            return false;
                        }
                        
                        if (isMove车师南 == false)
                        {
                            MovePanel("左上");
                            Dm.Delay(1000);
                            if (Dm.IsExistPic(210, 180, 820, 422, @"\bmp\马车.bmp", 0.6))
                            {
                                Dm.MoveToClick(943, 370);
                                Dm.Delay(2000);
                            }
                            else
                            {
                                MovePanel("右上");
                                Dm.Delay(1000);
                                if (Dm.IsExistPic(168, 257, 590, 438, @"\bmp\马车.bmp", 0.6))
                                {
                                    Dm.MoveToClick(515, 372);
                                    Dm.Delay(2000);
                                    MovePanel("右上");
                                }
                                else
                                {
                                    role.OutSubMessage("未找到马车,可能已经走过或马车无法识别.");
                                    isMove车师南 = true;
                                }
                                if (Dm.IsExistPic(424, 305, 592, 434, @"\bmp\马车.bmp", 0.6))
                                {
                                    role.OutSubMessage("马车在车师南.");
                                    isMove车师南 = true;
                                }
                            }
                          
                            return false;
                        }
                        if (isMove楼兰古城 == false)
                        {
                            MovePanel("右上");
                            Dm.Delay(1000);
                            Dm.MoveToClick(706,136);
                            Dm.Delay(2000);
                            if (Dm.IsExistPic(424, 305, 592, 434, @"\bmp\马车.bmp", 0.6))
                            {
                                role.OutSubMessage("马车在楼兰古城.");
                                isMove楼兰古城 = true;
                                return true;
                            }
                            return false;
                        }
                    }
                    //投掷骰子
                    if (!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp") && !Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp"))
                    {
                        Delegater.WaitTrue(() => Dm.MoveToClick(908, 478),
                                           () => Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"),
                                           () => Dm.Delay(1000), 4000);
                    }
                    return false;
                }, () => Dm.Delay(1000));
            }
            //图二
            if (Dm.IsExistPic(414, 420, 566, 492, @"\bmp\古城探索.bmp"))
            {
                Delegater.WaitTrue(() => Dm.FindPicAndClick(140, 380, 824, 512, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
            }
            //图三
            if (Dm.IsExistPic(659, 411, 822, 495, @"\bmp\古城探索.bmp"))
            {
                Delegater.WaitTrue(() => Dm.FindPicAndClick(140, 380, 824, 512, @"\bmp\古城探索.bmp"),
                                   () => Dm.IsExistPic(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                                   () => Dm.Delay(1000));
            }

            Delegater.WaitTrue(() =>
            {
                // //存在古城金币则没有次数,退出
                // if (Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp"))
                // {
                //     Delegater.WaitTrue(() => Dm.FindPicAndClick(384, 476, 572, 538, @"\bmp\古城返回主城.bmp"),
                //            () => Dm.IsExistPic(205, 57, 833, 163, @"\bmp\探宝.bmp"),
                //            () => Dm.Delay(1000));
                // }
                // //还可走,骰子已经投掷
                // if (Dm.IsExistPic(320,0,638,90, @"\bmp\古城还可走.bmp"))
                // {

                // }
                //if(!Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp")&& !Dm.IsExistPic(806, 419, 956, 535, @"\bmp\古城金币.bmp"))
                // {

                //     Dm.Delay(1000);
                //     Delegater.WaitTrue(() => Dm.MoveToClick(908, 478),
                //                        () => Dm.IsExistPic(320, 0, 638, 90, @"\bmp\古城还可走.bmp"),
                //                        () => Dm.Delay(1000),4000);
                // }





           
                return true;
            },() => Dm.Delay(1000));
            return TaskResult.Success;
            
        }
        /// <summary>
        /// 移动面板:
        /// </summary>
        /// <param name="direct">左下,左上,右下,右上</param>
        private void MovePanel(string direct)
        {
            switch(direct)
            {
                case "左下":
                    Dm.Swipe(304, 50, 666, 50);//向右拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 418, 80, 115);//向上拉
                    break;
                case "左上":
                    Dm.Swipe(304, 50, 666, 50);//向右拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 115, 80, 418);//向下拉
                    break;
                case "右下":
                    Dm.Swipe(666, 50, 304, 50);//向左拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 418, 80, 115);//向上拉
                    break;
                case "右上":
                    Dm.Swipe(666, 50, 304, 50);//向左拉
                    Dm.Delay(500);
                    Dm.Swipe(80, 115, 80, 418);//向下拉
                    break;
                default:
                    break;
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
                 if(Dm.GetColorNum(124, 507, 189, 552, "54.72.99-10.20.10", 0.9)>10)
                 {
                     if (Dm.FindPicAndClick(581, 514, 724, 580, @"\bmp\前往下层.bmp"))
                     {
                         if (Dm.IsExistPic(305, 230, 655, 458, @"\bmp\进入下层.bmp"))
                         {
                             Dm.FindPicAndClick(305, 230, 655, 458, @"\bmp\确定.bmp");
                         }
                     }
                     else
                         return true;
                 }
               if(Dm.GetColorNum(124, 507, 189, 552, "0.0.83-5.5.20", 0.9)>6)
                 {
                     Dm.FindPicAndClick(95, 231, 867, 515, @"\bmp\星星1.bmp");
                     Dm.Delay(1000);
                     Dm.MoveToClick(120, 253);
                     Dm.Delay(500);
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
