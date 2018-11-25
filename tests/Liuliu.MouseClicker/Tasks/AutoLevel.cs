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

            //int level = role.Level;
            while (true)
            {
                string taskName = dm.Ocr(0, 122, 114, 179, "60.19.85-5.5.40", 0.8);
                dm.DebugPrint("主线任务识别:" + taskName);
                for (int i = 0; i < 10; i++)
                {
                    dm.MoveToClick(21, 182);
                    dm.Delay(200);
                }
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
                    case "虎牢关":
                        dm.FindPicAndClick(395, 311, 574, 393, @"\bmp\上阵.bmp");
                        role.CloseMenu();
                        if(dm.IsExistPic(130,333,279,462, @"\bmp\EXP.bmp"))
                        {
                            dm.MoveToClick(192, 399);
                            dm.Delay(1000);
                            if(dm.IsExistPic(151,480,247,535, @"\bmp\EXP2.bmp"))
                            {
                               while(dm.FindPicAndClick(204, 435, 759, 492, @"\bmp\5.bmp",0,0,0.9))
                                {
                                    dm.Delay(1000);
                                }
                                while (dm.FindPicAndClick(204, 435, 759, 492, @"\bmp\5.bmp", 0, 0, 0.9))
                                {
                                    dm.Delay(1000);
                                }
                            }
                            break;
                        }
                      
                        GoToFighting("虎牢关",true);
                       break;
                    case "穿装备":
                        role.OpenMenu("武将");
                        dm.MoveToClick(234, 468);
                        dm.Delay(1000);
                        dm.MoveToClick(719, 464);
                        dm.Delay(200);
                        dm.MoveToClick(234, 468);
                        dm.Delay(1000);
                        dm.MoveToClick(719, 464);
                        dm.Delay(200);
                        dm.MoveToClick(234, 468);
                        dm.Delay(1000);
                        dm.MoveToClick(719, 464);
                        dm.Delay(200);
                        break;
                    case "买装备":
                        role.OpenMenu("装备");
                        dm.MoveToClick(164, 370);
                        dm.Delay(800);
                        dm.MoveToClick(292, 368);
                        dm.Delay(800);
                        dm.MoveToClick(418, 367);
                        dm.Delay(800);
                        dm.MoveToClick(542, 370);
                        dm.Delay(800);
                        dm.MoveToClick(673, 368);
                        dm.Delay(800);
                        dm.MoveToClick(797, 372);
                        dm.Delay(800);
                        break;
                    case "祭祀":
                        role.OpenMenu("资源");
                        if(dm.IsExistPic(0, 61, 106, 160,@"\bmp\祭祀银币.bmp"))
                             dm.MoveToClick(156, 455);
                        if (dm.IsExistPic(0, 61, 106, 160, @"\bmp\祭祀木材.bmp"))
                            dm.MoveToClick(328, 455);
                        break;
                    case "产量600":
                        role.GoToMap30("主城");
                        dm.MoveToClick(419, 245);//点击银币                     
                        //dm.MoveToClick(200, 200);//点击木材
                        dm.Delay(2000);
                        string a, b;
                        dm.MoveToClick(912, 114);//点击自动升级           
                        dm.Delay(1000);
                        Delegater.WaitTrue(() =>
                        {
                            a = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp", 0, 0, 0.7))
                            {
                                dm.DebugPrint("不存在加速锤！等待5s");
                                dm.MoveToClick(152, 429);
                                dm.Delay(5000);
                            }
                            dm.Delay(500);
                            b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (a != b)
                            {
                                dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                            }
                            return false;
                        },()=>dm.Delay(1000),20);
                        break;
                    case "刷装备":
                        dm.FindPicAndClick(395, 311, 574, 393, @"\bmp\上阵.bmp");
                        role.OpenMenu("装备");
                        dm.MoveToClick(784,480);
                        dm.Delay(800);
                        break;
                    case "卖装备":
                        role.OpenMenu("装备");
                        dm.MoveToClick(272, 28);
                        dm.Delay(800);
                        dm.MoveToClick(770, 479);
                        break;
                    case "下邳":
                        role.CloseMenu();
                        GoToFighting("下邳", true);
                        break;
                    case "木场":
                        role.GoToMap30("主城");
                        Delegater.WaitTrue(() => dm.MoveToClick(200, 200),
                            () => dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") && dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                            () => dm.Delay(1000));
                        dm.Delay(2000);
                        dm.MoveToClick(912, 114);//点击自动升级           
                        dm.Delay(1000);
                        Delegater.WaitTrue(() =>
                        {
                            a = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp", 0, 0, 0.7))
                            {
                                dm.DebugPrint("不存在加速锤！等待5s");
                                dm.MoveToClick(152, 429);
                                dm.Delay(5000);
                            }
                            dm.Delay(500);
                            b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (a != b)
                            {
                                dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                            }
                            return false;
                        }, () => dm.Delay(1000), 10);
                        break;
                    case "解雇":
                        role.OpenMenu("武将");
                        dm.MoveToClick(274, 32); //点击酒馆
                        dm.Delay(800);
                        if (dm.IsExistPic(116, 215, 658, 275, @"\bmp\周仓.bmp") && !dm.IsExistPic(116, 215, 658, 275, @"\bmp\张梁.bmp"))
                        {
                            dm.MoveToClick(204, 144); //点击第一个武将
                            dm.Delay(800);
                            dm.MoveToClick(410, 361); //点击确定
                            dm.Delay(800);
                        }
                        role.CloseWindow();
                        break;
                    case "招募":
                        role.OpenMenu("武将");
                        dm.MoveToClick(274, 32); //点击酒馆
                        dm.Delay(800);
                        if (dm.IsExistPic(116, 215, 658, 275, @"\bmp\周仓.bmp",0.7) && dm.IsExistPic(116, 215, 658, 275, @"\bmp\张梁.bmp", 0.7))
                        {
                            dm.FindPicAndClick(116, 215, 658, 275, @"\bmp\周仓.bmp", 31, 172, 0.7);
                        }
                        if (dm.IsExistPic(116, 215, 658, 275, @"\bmp\张辽.bmp", 0.7) && dm.IsExistPic(116, 215, 658, 275, @"\bmp\张梁.bmp", 0.7))
                        {
                            if(dm.IsExistPic(116, 215, 658, 275, @"\bmp\华雄.bmp", 0.7) || dm.IsExistPic(116, 215, 658, 275, @"\bmp\周仓.bmp", 0.7))
                            {
                                dm.FindPicAndClick(116, 215, 658, 275, @"\bmp\张辽.bmp", 31, 172, 0.7);
                                break;
                            }
                            role.CloseWindow();
                            role.OpenMenu("资源");
                            for (int i = 0; i < 20; i++)
                            {
                                dm.MoveToClick(156, 455);
                                dm.Delay(200);
                            }
                            role.CloseWindow();
                            role.OpenMenu("武将");
                            dm.MoveToClick(274, 32); //点击酒馆
                            dm.Delay(800);
                            if (dm.FindPicAndClick(116, 215, 658, 275, @"\bmp\张辽.bmp", 31, 172, 0.7))
                            {
                                dm.Delay(2000);
                                if(dm.IsExistPic(116, 215, 658, 275, @"\bmp\张辽.bmp", 0.7))
                                {
                                    dm.MoveToClick(204, 144); //点击第一个武将
                                    dm.Delay(800);
                                    dm.MoveToClick(410, 361); //点击确定
                                    dm.Delay(2000);
                                }
                            }
                            dm.FindPicAndClick(116, 215, 658, 275, @"\bmp\张辽.bmp", 31, 172, 0.7);
                        }
                        break;
                    case "科技":
                        role.OpenMenu("科技");
                        Delegater.WaitTrue(()=>
                        {
                            dm.FindPicAndClick(656, 208, 790, 269, @"\bmp\注资.bmp");
                            dm.Delay(2000);
                            if (dm.IsExistPic(774,406,956,505, @"\bmp\木材不足.bmp"))
                            {
                                dm.MoveToClick(855, 478);
                                dm.Delay(2000);
                                for (int i = 0; i < 5; i++)
                                {
                                    dm.MoveToClick(334, 458);
                                    dm.Delay(500);
                                }
                                role.CloseWindow();
                                role.OpenMenu("科技");
                            }
                            if(dm.FindPicAndClick(656, 208, 790, 269, @"\bmp\研究.bmp",0,0,0.7))
                            {
                                dm.Delay(1000);
                                return true;
                            }
                           
                            return false;
                        },()=> dm.Delay(1000),10);
                        break;
                    case "农田":
                        role.GoToMap30("主城");
                        Delegater.WaitTrue(() => dm.MoveToClick(165,348),
                            () => dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") && dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                            () => dm.Delay(1000));
                        dm.Delay(2000);
                        dm.MoveToClick(912, 114);//点击自动升级           
                        dm.Delay(1000);
                        Delegater.WaitTrue(() =>
                        {
                            a = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp", 0, 0, 0.7))
                            {
                                dm.DebugPrint("不存在加速锤！等待5s");
                                dm.MoveToClick(152, 429);
                                dm.Delay(2000);
                            }
                            dm.Delay(500);
                            b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (a != b)
                            {
                                dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                            }
                            return false;
                        }, () => dm.Delay(1000), 10);
                        break;
                    case "皇城":
                        role.GoToMap30("主城");
                        dm.Delay(2000);
                        Delegater.WaitTrue(() => dm.MoveToClick(667, 180),
                            () => dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                            () => dm.Delay(1000));
                        Delegater.WaitTrue(() => dm.MoveToClick(337, 446),
                            () => dm.IsExistPic(266, 356, 619, 486, @"\bmp\占领.bmp"),
                            () => dm.Delay(1000));
                        dm.FindPicAndClick(266, 356, 619, 486, @"\bmp\占领.bmp");
                        dm.Delay(2000);
                        dm.MoveToClick(612, 122);
                        dm.Delay(1000);
                        dm.MoveToClick(749, 128);
                        dm.Delay(1000);
                        dm.MoveToClick(807, 259); //点击战斗
                        Delegater.WaitTrue(() => {
                                if (dm.IsExistPic(330, 45, 639, 184, @"\bmp\胜利.bmp"))
                                {
                                    dm.MoveToClick(916, 45); //点击返回
                                    dm.Delay(1000);
                                    return true;
                                }
                                return false;
                            },() => dm.Delay(1000));
                        break;
                    case "俸禄":
                        role.OpenMenu("排行");
                        dm.Delay(1000);
                        dm.MoveToClick(630,469);//点击俸禄        
                        dm.Delay(1000);
                        break;
                    case "兵营":
                        role.GoToMap30("主城");
                        Delegater.WaitTrue(() => dm.MoveToClick(334,443),
                            () => dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") && dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                            () => dm.Delay(1000));
                        break;
                    case "募兵700":
                       
                        Delegater.WaitTrue(() =>
                        {
                            role.GoToMap30("主城");
                            return dm.MoveToClick(334, 443);
                        },() => dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp") && dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp"),
                          () => dm.Delay(1000));
                        dm.Delay(2000);
                        dm.MoveToClick(912, 114);//点击自动升级           
                        dm.Delay(1000);
                        Delegater.WaitTrue(() =>
                        {
                            a = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp", 0, 0, 0.7))
                            {
                                dm.DebugPrint("不存在加速锤！等待2s");
                                dm.MoveToClick(152, 429);
                                dm.Delay(2000);
                            }
                            dm.Delay(500);
                            b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                            if (a != b)
                            {
                                dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
                            }
                            return false;
                        }, () => dm.Delay(1000), 15);
                        break;
                    case "世界":
                        role.GoToMap("世界");
                        break;
                    case "迷雾":
                        //role.GoToMap("世界");
                        return TaskResult.Finished;
                        break;
                    default:
                        ClickXiaoQian();
                        break;
                }
                dm.Delay(2000);
            }
            return TaskResult.Finished;
            
        }

        private bool GoToFighting(string area,bool isSkip=false)
        {
            Role role = (Role)Role;
            DmPlugin dm = role.Window.Dm;
            role.GoToMap30("副本");
            // role.GoToFubenArea(area);
            if (area == "下邳")
            {
                dm.Swipe(670, 427, 93, 425);
                dm.Delay(1000);
            }
            Delegater.WaitTrue(() =>
            {
                dm.MoveToClick(21, 182);
                if (dm.IsExistPic(116, 72, 936, 351, @"\bmp\战斗.bmp"))
                    return true;
                dm.FindPicAndClick(395, 311, 574, 393, @"\bmp\上阵.bmp");
                return false;
            }, () => dm.Delay(500), 10);

            if(Delegater.WaitTrue(() =>
            {
                dm.FindPicAndClick(395, 311, 574, 393, @"\bmp\上阵.bmp");
                dm.FindPicAndClick(116, 72, 936, 351, @"\bmp\战斗.bmp");
                if (dm.IsExistPic(394, 216, 567, 307, @"\bmp\VS.bmp"))
                {
                    //补充兵力
                    dm.MoveToClick(612, 122);
                    dm.Delay(1000);
                    
                    dm.MoveToClick(749, 128);
                    dm.Delay(1000);
                    dm.MoveToClick(807,259); //点击战斗
                }
                if (!dm.IsExistPic(394, 216, 567, 307, @"\bmp\VS.bmp")&&dm.IsExistPic(762,4,953,87, @"\bmp\返回.bmp")&&isSkip)
                {
                    dm.MoveToClick(840, 43); //点击跳过
                    dm.Delay(3000);
                }
                
                if (dm.IsExistPic(330,45,639,184, @"\bmp\胜利.bmp"))
                {
                    dm.MoveToClick(916,45); //点击返回
                    dm.Delay(1000);
                    return true;
                }
                if (dm.IsExistPic(318, 36, 637,195, @"\bmp\失败.bmp"))
                {
                    dm.MoveToClick(916, 45); //点击返回
                    dm.Delay(1000);
                    return true;
                }
                return false;
            },()=>dm.Delay(1000),10))
            {
                return true;
            }
            else
            {
               return GoToFighting(area, true);
            }
           
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
