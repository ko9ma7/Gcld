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
            try
            {
                if (context.Settings.IsAutoWeapon)
                    return 1;
                if (context.Settings.IsAutoBuilding)
                    return 2;
                if (context.Settings.IsAutoClear)
                    return 3;
                if (context.Settings.IsRefreshEquipment)
                    return 4;
                if (context.Settings.IsAutoClear2)
                {
                    equipmentTypeDict = context.Settings.EquipmentTypeDict;
                    return 5;
                }
                if (context.Settings.IsBuyEquipment)
                    return 6;
                if (context.Settings.IsAutoFuben)
                    return 7;
            } catch(Exception ex)
            {
                Dm.DebugPrint(ex.Message);
            }
            return 1;
        }
        private Dictionary<int,List<bool?>> equipmentTypeDict = null;
        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动兵器",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="自动建筑",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="自动洗练",Order=3,RunFunc=RunStep3 },
                new TaskStep() {Name="刷新装备",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="指定洗练",Order=5,RunFunc=RunStep5 },
                new TaskStep() {Name="购买装备",Order=6,RunFunc=RunStep6 },
                new TaskStep() {Name="自动副本",Order=7,RunFunc=RunStep7 },


             };
            return steps;
        }


        private TaskResult RunStep7(TaskContext arg)
        {
            Role role = (Role)Role;
            role.GoToMap("副本");
            int count = 0;
            while (true)
            {
                if (Dm.FindPicAndClick(116, 72, 936, 351, @"\bmp\战斗.bmp"))
                {
                    count = 0;
                    if (role.GoToFighting() == false)
                    {
                        Dm.DebugPrint("装备不够好或等级不够，提升实力再来！");
                        break;
                    }
                }
                else
                {
                    count++;
                    if (count > 10)
                        break;
                    Dm.Swipe(670, 427, 93, 427); //向右划
                    Dm.Delay(1000);
                }
                Dm.Delay(2000);
            }
            role.CloseWindow();
            return TaskResult.Success;
        }


        class Goods
        {
            /// <summary>
            /// 物品位置序号
            /// </summary>
            public int Pos { get; set; }
            /// <summary>
            /// 物品颜色
            /// </summary>
            public Color Color { get; set; }
            /// <summary>
            /// 星星等级
            /// </summary>
            public int StarLevel { get; set; }
            /// <summary>
            /// 物品类型
            /// </summary>
            public GoodsType Type { get; set; }
            /// <summary>
            /// 物品购买坐标
            /// </summary>
            public Tuple<int, int> Buypos { get; set; }
        }
        enum GoodsType
        {
            无法识别 = -1,
            枪,
            甲,
            符,
            马,
            披风,
            帅旗,
            图纸,
        }
        enum Color
        {
            无法识别 = -1,
            白,
            蓝,
            绿,
            黄,
            红,
            紫,
        }
        private Color GetColor(int x1, int y1, int x2, int y2)
        {
            int intX, intY;
            // int 白色数量=0, 蓝色数量=0, 绿色数量=0, 黄色数量=0, 红色数量=0, 紫色数量=0;
            if (Dm.FindColor(x1, y1, x2, y2, "D1D1D1-303030", 1.0, 0, out intX, out intY))
                return Color.白;
            //白色数量 = Dm.GetColorNum(x1, y1, x2, y2, "D1D1D1-2D2D2D", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "698EC6-111821", 1.0, 0, out intX, out intY))
                return Color.蓝;
            //蓝色数量 = Dm.GetColorNum(x1, y1, x2, y2, "698EC6-111821", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "5CB52C-15290B", 1.0, 0, out intX, out intY))
                return Color.绿;
            // 绿色数量 = Dm.GetColorNum(x1, y1, x2, y2, "5CB52C-15290B", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "CD9735-31250D", 1.0, 0, out intX, out intY))
                return Color.黄;
            // 黄色数量 = Dm.GetColorNum(x1, y1, x2, y2, "CD9735-31250D", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "C44C4C-341414", 1.0, 0, out intX, out intY))
                return Color.红;
            //红色数量 = Dm.GetColorNum(x1, y1, x2, y2, "C44C4C-341414", 0.9, true);
            if (Dm.FindColor(x1, y1, x2, y2, "A85EC2-2A1730", 1.0, 0, out intX, out intY))
                return Color.紫;
            //紫色数量 = Dm.GetColorNum(x1, y1, x2, y2, "A85EC2-2A1730", 0.9, true);
            // int[] 颜色数量 = new int[] { 白色数量, 蓝色数量, 绿色数量, 黄色数量,红色数量, 紫色数量 };
            // int max = 颜色数量.Max();
            // return (Color)颜色数量.ToList().IndexOf(max);
            return Color.无法识别;
        }

        private TaskResult RunStep6(TaskContext arg)
        {
            Role role = (Role)Role;
            Dm.UseDict(1);
            int level = Dm.GetOcrNumber(101, 31, 159, 59, "40.30.88-20.30.30", 0.8);
            Dm.UseDict(0);
            //获取所需装备件数
            //Delegater.WaitTrue(() => role.OpenMenu("武将"), () => role.IsExistWindowMenu("武将"), () => Dm.Delay(1000));
            //Delegater.WaitTrue(() => role.OpenWindowMenu("武将"),
            //                   () => Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenMenu("装备"), () => role.IsExistWindowMenu("商店"), () => Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenWindowMenu("商店"),
                               () => Dm.Delay(1000));

            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            dict.Add(1, new int[] { 115, 134, 217, 174, 104, 272, 212, 312, 165, 369, 0, 0 });
            dict.Add(2, new int[] { 235, 135, 350, 173, 233, 271, 344, 311, 296, 369, 0, 0 });
            dict.Add(3, new int[] { 365, 135, 475, 174, 361, 273, 464, 313, 418, 369, 0, 0 });
            dict.Add(4, new int[] { 488, 133, 604, 176, 486, 276, 581, 311, 551, 374, 0, 0 });
            dict.Add(5, new int[] { 614, 131, 732, 175, 614, 270, 721, 314, 675, 369, 0, 0 });
            dict.Add(6, new int[] { 740, 129, 857, 178, 744, 272, 843, 312, 802, 372, 0, 0 });
            Delegater.WaitTrue(() =>
            {
                List<Goods> list = new List<Goods>();
                Dm.StartWatch();
                for (int i = 1; i <= 6; i++)
                {
                    var color = GetColor(dict[i][0], dict[i][1], dict[i][2], dict[i][3]);
                    var starLevel = Dm.GetPicCount(dict[i][4], dict[i][5], dict[i][6], dict[i][7], @"\bmp\星星1.bmp");
                    list.Add(new Goods() { Pos = i, StarLevel = starLevel, Color = color, Buypos = new Tuple<int, int>(dict[i][8], dict[i][9]) });
                    Dm.DebugPrint(string.Format("位置{0}：星级【{1}】,颜色【{2}】", i, starLevel, color));
                }
                Dm.StopWatch();
                List<Goods> buyList = null;
                if (level >= 16 && level < 28) //蓝
                {
                    buyList = list.Where(x => x.Color == Color.蓝).ToList();
                }
                else if (level >= 28 && level < 36) //绿
                {
                    buyList = list.Where(x => x.Color == Color.绿).ToList();
                }
                else if (level >= 36 && level < 53)//黄
                {
                    buyList = list.Where(x => x.Color == Color.黄 && x.StarLevel == 1).ToList();
                }
                else if (level >= 53 && level < 70)//红
                {
                    buyList = list.Where(x => x.Color == Color.红 && x.StarLevel == 2).ToList();
                }
                else if (level >= 70)//紫
                {
                    buyList = list.Where(x => x.Color == Color.紫 && x.StarLevel == 3).ToList();
                }
                else
                {
                    Dm.DebugPrint("人物等级无法识别！" + level);
                    return true;
                }
                if (buyList != null)
                {
                    foreach (var goods in buyList)
                    {
                        Dm.MoveToClick(goods.Buypos.Item1, goods.Buypos.Item2);
                        Dm.Delay(1000);
                    }
                }

                Dm.FindStrAndClick(718, 448, 857, 502, "刷新", "86.17.70-5.5.25");
                Dm.Delay(500);
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\金币秒CD.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    return true;
                }
                //出现适合装备
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\适合您的装备.bmp"))
                {
                    // Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                //出现稀有物品
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\稀有物品.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                return Dm.IsExistStr(718, 448, 857, 502, "清除", "86.17.70-5.5.25");
            }, () => Dm.Delay(500));
            role.CloseWindow();
            return TaskResult.Success;
        }

        enum EquipmentType
        {
            未知类型 = -1,
            攻击,
            防御,
            掌控,
            血量,
            强防,
            强壮,
            强攻
        }
        private EquipmentType GetEquipmentType()
        {
            int intX, intY;
            int result = Dm.FindPic(781, 315, 861, 402, @"\bmp\攻击.bmp|\bmp\防御.bmp|\bmp\掌控.bmp|\bmp\血量.bmp|\bmp\强防.bmp|\bmp\强壮.bmp|\bmp\强攻.bmp|", "404040", 0.6, 0, out intX, out intY);
            return (EquipmentType)result;
        }
        class Equipment
        {
            public EquipmentType 类型;
            public bool? IsHave=false;
        }
        class 套装
        {
            public Equipment 麒麟双枪;
            public Equipment 麒麟;
            public Equipment 三昧纯阳铠;
            public Equipment 蝶凤舞阳;
            public Equipment 伏龙帅印;
            public Equipment 蟠龙华盖;
        }
      
       static List<套装> List { get; set; } 
        private TaskResult RunStep5(TaskContext context)
        {
            Role role = (Role)context.Role;
            套装 青龙套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.血量 }, 麒麟 = new Equipment() { 类型 = EquipmentType.血量 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.血量 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.血量 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.血量 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.血量 } };
            套装 白虎套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 } };
            套装 朱雀套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强壮 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强壮 } };
            套装 鲮鲤套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.掌控 }, 麒麟 = new Equipment() { 类型 = EquipmentType.掌控 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.掌控 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强防 } };
            套装 玄武套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.防御 }, 麒麟 = new Equipment() { 类型 = EquipmentType.防御 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.防御 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.防御 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.防御 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.防御 } };
            套装 霸下套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强防 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强防 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.掌控 } };
            套装 驱虎套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 } };
            套装 烛龙套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强防 } };
            套装 凤凰套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.强攻 } };
            套装 灵龟套装 = new 套装() { 麒麟双枪 = new Equipment() { 类型 = EquipmentType.强攻 }, 麒麟 = new Equipment() { 类型 = EquipmentType.强攻 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentType.掌控 } };
            List = new List<套装>() { 青龙套装, 白虎套装, 朱雀套装, 鲮鲤套装, 玄武套装, 霸下套装, 驱虎套装, 烛龙套装, 凤凰套装, 灵龟套装 };
            for (int i = 0; i < 10; i++)
            {
                    套装 temp = new 套装();
                    temp.麒麟双枪 = new Equipment();
                    temp.麒麟双枪.类型 = List[i].麒麟双枪.类型;
                    temp.麒麟双枪.IsHave = equipmentTypeDict[i][0];

                    temp.麒麟 = new Equipment();
                    temp.麒麟.类型 = List[i].麒麟.类型;
                    temp.麒麟.IsHave = equipmentTypeDict[i][1];

                    temp.三昧纯阳铠 = new Equipment();
                    temp.三昧纯阳铠.类型 = List[i].三昧纯阳铠.类型;
                    temp.三昧纯阳铠.IsHave = equipmentTypeDict[i][2];

                    temp.蝶凤舞阳 = new Equipment();
                    temp.蝶凤舞阳.类型 = List[i].蝶凤舞阳.类型;
                    temp.蝶凤舞阳.IsHave = equipmentTypeDict[i][3];

                    temp.伏龙帅印 = new Equipment();
                    temp.伏龙帅印.类型 = List[i].伏龙帅印.类型;
                    temp.伏龙帅印.IsHave = equipmentTypeDict[i][4];

                    temp.蟠龙华盖 = new Equipment();
                    temp.蟠龙华盖.类型 = List[i].蟠龙华盖.类型;
                    temp.蟠龙华盖.IsHave = equipmentTypeDict[i][5];
                    List[i] = temp;
           
            }
            foreach (var taozhuang in List)
            {
                Dm.DebugPrint(taozhuang.麒麟双枪.IsHave.ToString()+ taozhuang.麒麟.IsHave.ToString()+ taozhuang.三昧纯阳铠.IsHave.ToString()+ taozhuang.蝶凤舞阳.IsHave.ToString()+taozhuang.伏龙帅印.IsHave.ToString()+ taozhuang.蟠龙华盖.IsHave.ToString());
            }
            Delegater.WaitTrue(() =>
            {
              Dm.MoveToClick(631, 448);
              Dm.Delay(500);
              if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp",0.8,false))
              {
                Dm.Delay(500);
               }
               if(Dm.IsExistPic(379,213,475,255,@"\bmp\隐藏技能.bmp",0.8,false))
                {
                    var type = GetEquipmentType();
                   // Dm.DebugPrint("需要的类型:" + ((EquipmentType)equipmentType).ToString());
                    Dm.DebugPrint("当前类型:" + type.ToString());
                    string ocr = Dm.Ocr(645, 121, 787, 168, "AB5BC6-25142B", 0.8);
                    Dm.DebugPrint(ocr);
                    if (ocr == "")
                    {
                        Dm.DebugPrint("未能识别装备类型.");
                        return true;
                    }

                    套装 taozhuang = null;
                    if(ocr.Contains("双枪"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.麒麟双枪.类型 == type && x.麒麟双枪.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.麒麟双枪.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (ocr.Contains("麒麟")&&!ocr.Contains("双枪"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.麒麟.类型 == type && x.麒麟.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.麒麟.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (ocr.Contains("三昧纯阳铠"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.三昧纯阳铠.类型 == type && x.三昧纯阳铠.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.三昧纯阳铠.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (ocr.Contains("蝶凤舞阳"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.蝶凤舞阳.类型 == type && x.蝶凤舞阳.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.蝶凤舞阳.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (ocr.Contains("伏龙帅印"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.伏龙帅印.类型 == type && x.伏龙帅印.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.伏龙帅印.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (ocr.Contains("蟠龙华盖"))
                    {
                        taozhuang = List.FirstOrDefault(x => x.蟠龙华盖.类型 == type && x.蟠龙华盖.IsHave == false);
                        if (taozhuang != null)
                        {
                            taozhuang.蟠龙华盖.IsHave = true;
                            Dm.MoveToClick(550, 361);
                            return true;
                        }
                    }
                    if (type != EquipmentType.未知类型)
                        Dm.MoveToClick(409, 362);
                }
                return false;
            });
            return TaskResult.Finished;
        }

        private TaskResult RunStep4(TaskContext context)
        {
            Role role = (Role)context.Role;
            Delegater.WaitTrue(() => Dm.FindPicAndClick(856, 448, 958, 536, @"\bmp\菜单未打开.bmp"),
                               () => Dm.IsExistPic(856, 448, 958, 536, @"\bmp\菜单打开.bmp"),()=>Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenMenu("装备"),
                              () => role.OpenWindowMenu ("商店"),() => Dm.Delay(1000));
            Delegater.WaitTrue(() =>
            {
                Dm.FindStrAndClick(718, 448, 857, 502,"刷新", "86.17.70-5.5.25");
                if(Dm.IsExistPic(283,192,668,411,@"\bmp\金币秒CD.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    return true;
                }
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\适合您的装备.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\稀有物品.bmp"))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                return Dm.IsExistStr(718, 448, 857, 502, "清除", "86.17.70-5.5.25");
            },()=>Dm.Delay(500));
            role.CloseWindow();
            return TaskResult.Finished;
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
                //dm.MoveToClick(317, 460);//点击兵营
                dm.MoveToClick(419, 245);//点击银币
                //dm.MoveToClick(200, 200);//点击木材
                dm.Delay(2000);
            }
            string a, b;
            dm.FindPicAndClick(852, 78, 952, 148, @"\bmp\自动升级.bmp");
            dm.Delay(1000);
            Delegater.WaitTrue(() =>
            {
               a=dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                if (!dm.FindPicAndClick(102, 48, 857, 468, @"\bmp\加速锤.bmp",0,0,0.7))
                {
                    dm.DebugPrint("不存在加速锤！等待5s");
                    dm.MoveToClick(152, 429);
                    dm.Delay(5000);
                }
                dm.Delay(500);
                b = dm.FetchWord(903, 103, 954, 145, "eaeaea-202020", "建筑队列数");
                if (a!=b)
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
