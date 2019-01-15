using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models;
using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Damo;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using Newtonsoft.Json.Linq;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
                if (context.Settings.StepName == "自动兵器")
                    return 1;
                if (context.Settings.StepName == "自动建筑")
                    return 2;
                if (context.Settings.StepName == "自动洗练")
                    return 5;
                if (context.Settings.StepName == "购买装备")
                    return 6;
                if (context.Settings.StepName == "自动副本")
                    return 7;
            }
            catch (Exception ex)
            {
                Dm.DebugPrint(ex.Message);
            }
            return 1;
        }
        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动兵器",Order=1,RunFunc=RunStep1 },
                new TaskStep() {Name="自动建筑",Order=2,RunFunc=RunStep2 },
                new TaskStep() {Name="",Order=3,RunFunc=RunStep2 },
                new TaskStep() {Name="刷新装备",Order=4,RunFunc=RunStep4 },
                new TaskStep() {Name="自动洗练",Order=5,RunFunc=RunStep5 },
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
                if (Dm.FindPicAndClick(116, 72, 936, 351, @"\bmp\战斗.bmp") ||
                    Dm.FindMultiColorAndClick(122, 58, 318, 196, "ffb40b", "19|-17|ffb814,35|0|ffb40b-202020,34|-34|fff303-202020,25|-25|ffdd12,26|-4|ff8804,8|-7|ff9907,28|-29|ffe009", 17, 59))
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
                    if (count > 5)
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
        int[] needs = new int[] { 0, 0, 0, 0, 0, 0 };//枪甲符马袍旗

        private void GetEquipmentProperty(int x, int y, int i)
        {
            Dm.Delay(1000);
            Dm.MoveToClick(x, y);
            Dm.Delay(1000);
            int count = Dm.GetColorNum(205, 448, 264, 499, "201a19-202020", 0.9);
            if (Dm.GetColorNum(584, 76, 633, 114, "edd1a9 -202020|a49074-202020", 0.9) > 100)
            {
                if (count > 2000)
                {
                    needs[i] += 1;
                    return;
                }
                else
                {
                    Dm.MoveToClick(234, 469);
                    Dm.Delay(1000);
                    Dm.MoveToClick(x, y);
                    Dm.Delay(1000);
                }
            }

            if (IsOptimalColor() == false)
            {
                if (count > 2000)
                    needs[i] += 1;
                else
                {
                    Dm.MoveToClick(234, 469);
                    Dm.Delay(1000);
                    if (IsOptimalColor() == false)
                        needs[i] += 1;
                    else
                        Delegater.WaitTrue(() =>
                        {
                            if (Dm.FindPicAndClick(658, 437, 782, 491, @"\bmp\穿上装备.bmp", 0, 0, 0.7))
                            {
                                Dm.Delay(1000);
                                if (Dm.IsExistPic(537, 194, 669, 277, @"\bmp\兵力损失.bmp"))
                                    Dm.MoveToClick(415, 359);
                                return true;
                            }
                            return false;
                        }, () => Dm.Delay(1000));

                }

            }


        }
        private List<string> taozhuangList = new List<string>();
        private void GetSelectedGeneralEquipment(int x1, int y1, int x2, int y2, int a, int b)
        {
            Role role = (Role)Role;
            if (Dm.GetColorNum(x1, y1, x2, y2, "DDDDDD-222222", 0.9, false) > 100)
            {
                //GetEquipmentProperty(465, 177, 0);//枪
                //GetEquipmentProperty(467, 250, 1);//甲
                //GetEquipmentProperty(468, 319, 2);//帅印
                //GetEquipmentProperty(535, 179, 3);//马
                //GetEquipmentProperty(536, 251, 4); //披风
                //GetEquipmentProperty(538, 322, 5);//旗子\
                Dm.MoveToClick(a, b);
                Dm.Delay(1000);
                Dm.MoveToClick(465, 177);
                Dm.Delay(1000);

                var obj = role.GameHelper.GetData(Const.GENERAL_GET_WEAREQUIP);
                JArray wel = obj.action.data.equips;
                List<WearEquip> wearEquipList = new List<WearEquip>();
                if (wel != null)
                {
                    wearEquipList = JsonHelper.FromJson<List<WearEquip>>(wel.ToString());
                    foreach (var wearEquip in wearEquipList)
                    {
                        if (wearEquip.itemName.Contains("套装"))
                        {
                            if (!taozhuangList.Contains(wearEquip.itemName))
                                taozhuangList.Add(wearEquip.itemName);
                        }
                    }
                }

            }
        }
        Color MaxColor = Color.无法识别;
        private bool IsOptimalColor()
        {
            var color = GetColor(640, 77, 799, 117);
            Dm.DebugPrint(color.ToString());
            if (color > MaxColor)
                MaxColor = color;
            return color >= MaxColor;
        }

        private TaskResult RunStep6(TaskContext arg)
        {
            Role role = (Role)Role;
            taozhuangList.Clear();
            role.CloseWindow();
            #region 数字识别等级
            //Dm.UseDict(1);
            // int level = Dm.GetOcrNumber(101, 31, 159, 59, "40.30.88-20.30.30");
            //  Dm.UseDict(0);
            int level = role.Level;
            Dm.DebugPrint("人物等级：" + level);
            if (level >= 16 && level < 28) //蓝
                MaxColor = Color.蓝;
            else if (level >= 28 && level < 36) //绿
                MaxColor = Color.绿;
            else if (level >= 36 && level < 53)//黄
                MaxColor = Color.黄;
            else if (level >= 53 && level < 70)//红
                MaxColor = Color.红;
            else if (level >= 70)//紫
                MaxColor = Color.紫;
            else
            {
                Dm.DebugPrint("人物等级无法识别！" + level);
                MaxColor = Color.无法识别;
                role.CloseWindow();
                return TaskResult.Finished;
            }
            #endregion
            for (int i = 0; i < 6; i++)
            {
                needs[i] = 0;
            }
            int count = 0;
            //获取所需装备件数
            if (MaxColor == Color.紫)
            {
                Delegater.WaitTrue(() => role.OpenMenu("武将"), () => role.IsExistWindowMenu("将领"), () => Dm.Delay(1000));
                Delegater.WaitTrue(() => role.OpenWindowMenu("将领"),
                                   () => Dm.Delay(1000));
                GetSelectedGeneralEquipment(86, 68, 177, 149, 152, 107);
                GetSelectedGeneralEquipment(86, 156, 173, 241, 154, 194);
                GetSelectedGeneralEquipment(84, 244, 176, 326, 153, 286);
                GetSelectedGeneralEquipment(83, 332, 174, 417, 153, 375);
                Dm.DebugPrint("需要装备：" + needs[0] + " " + needs[1] + " " + needs[2] + " " + needs[3] + " " + needs[4] + " " + needs[5]);
                string temp = "";

                foreach (var item in taozhuangList)
                {
                    temp = temp + item + " ";
                    if (item.Contains("极"))
                    {
                        role.CloseWindow();
                        return TaskResult.Finished;
                    }
                    if (item.Contains("真"))
                    {
                        count = count + 2;
                        continue;
                    }
                    if (item.Contains("套装"))
                    {
                        count = count + 1;
                    }
                }
                if (count >= 10)
                {
                    role.CloseWindow();
                    return TaskResult.Finished;
                }
                Debug.WriteLine("已经拥有套装：" + temp);
                role.CloseWindow();
            }
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
            Delegater.WaitTrue((Func<bool>)(() =>
            {
                Dm.FindStrAndClick(718, 448, 857, 502, "刷新", "86.17.70-5.5.25");
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\金币秒CD.bmp", 0.8, false))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    return true;
                }
                //出现适合装备
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\适合您的装备.bmp", 0.8, false))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    List<Goods> list = new List<Goods>();
                    // Dm.StartWatch();
                    for (int i = 1; i <= 6; i++)
                    {
                        var color = GetColor(dict[i][0], dict[i][1], dict[i][2], dict[i][3]);
                        var starLevel = Dm.GetPicCount(dict[i][4], dict[i][5], dict[i][6], dict[i][7], @"\bmp\星星1.bmp");
                        list.Add(new Goods() { Pos = i, StarLevel = starLevel, Color = color, Buypos = new Tuple<int, int>(dict[i][8], dict[i][9]) });
                        //Dm.DebugPrint(string.Format("位置{0}：星级【{1}】,颜色【{2}】", i, starLevel, color));
                    }
                    // Dm.StopWatch();
                    List<Goods> buyList = null;
                    if (list.Max(x => x.Color) != MaxColor)
                    {
                        Dm.DebugPrint("最大颜色错误,应是:" + list.Max(x => x.Color) + ",等级识别的maxcolor:" + MaxColor.ToString());
                        MaxColor = list.Max(x => x.Color);

                        if (MaxColor == Color.紫)
                        {
                            role.CloseWindow();
                            Delegater.WaitTrue(() => role.OpenMenu("武将"), () => role.IsExistWindowMenu("将领"), () => Dm.Delay(1000));
                            Delegater.WaitTrue(() => role.OpenWindowMenu("将领"),
                                               () => Dm.Delay(1000));
                            GetSelectedGeneralEquipment(86, 68, 177, 149, 152, 107);
                            GetSelectedGeneralEquipment(86, 156, 173, 241, 154, 194);
                            GetSelectedGeneralEquipment(84, 244, 176, 326, 153, 286);
                            GetSelectedGeneralEquipment(83, 332, 174, 417, 153, 375);
                            Dm.DebugPrint("需要装备：" + needs[0] + " " + needs[1] + " " + needs[2] + " " + needs[3] + " " + needs[4] + " " + needs[5]);
                            role.CloseWindow();
                            Delegater.WaitTrue(() => role.OpenMenu("装备"), () => role.IsExistWindowMenu("商店"), () => Dm.Delay(1000));
                            Delegater.WaitTrue(() => role.OpenWindowMenu("商店"),
                                               () => Dm.Delay(1000));
                        }
                    }
                    if (MaxColor == Color.白 || MaxColor == Color.蓝 || MaxColor == Color.绿)
                    {
                        buyList = list.Where(x => x.Color == MaxColor).ToList();
                    }
                    else if (MaxColor == Color.黄)//黄
                    {
                        buyList = list.Where(x => x.Color == Color.黄 && x.StarLevel == 1).ToList();
                    }
                    else if (MaxColor == Color.红)//红
                    {
                        buyList = list.Where(x => x.Color == Color.红 && x.StarLevel == 2).ToList();
                    }
                    else if (MaxColor == Color.紫)//紫
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
                        Dm.Delay(2000);
                        foreach (var goods in buyList)
                        {
                            try
                            {
                                StoreItem items = role.GameHelper.GetStoreItem();
                                if (items == null)
                                {
                                    Dm.DebugPrint("Error:获取商店数据错误。");
                                    role.CloseWindow();
                                    return true;
                                }
                                if (int.Parse(items.nowItemNum) >= int.Parse(items.maxItemNum))
                                {
                                    Dm.DebugPrint("Error:仓库数量达到上限。");
                                    role.CloseWindow();
                                    return true;
                                }
                                if (items.items[goods.Pos - 1].curItemNum == null)
                                {
                                    Dm.DebugPrint("获取的商品跟识别不一致。");

                                    Dm.Delay(2000);
                                    continue;
                                }


                                if (MaxColor >= Color.紫)
                                {
                                    if (int.Parse(items.items[goods.Pos - 1].curItemNum) < (10 - count))
                                    {
                                        Dm.MoveToClick(goods.Buypos.Item1, goods.Buypos.Item2);
                                        Dm.Delay(1000);
                                        break;
                                    }

                                }
                                else
                                {
                                    Dm.MoveToClick(goods.Buypos.Item1, goods.Buypos.Item2);
                                    Dm.Delay(1000);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            { Debug.WriteLine(ex.Message); }

                        }
                    }
                    Dm.FindStrAndClick(718, 448, 857, 502, "刷新", "86.17.70-5.5.25");
                    Dm.Delay(1000);
                    if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\适合您的装备.bmp"))
                        Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店确定.bmp");
                }
                //出现稀有物品
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\稀有物品.bmp", 0.8, false))
                {
                    Dm.FindPicAndClick(283, 192, 668, 411, @"\bmp\商店取消.bmp");
                    Dm.Delay(500);
                    Dm.MoveToClick(168, 370);
                }
                return Dm.IsExistStr(718, 448, 857, 502, "清除", "86.17.70-5.5.25");
            }), () => Dm.Delay(200));
            Dm.DebugPrint("需要装备：" + needs[0] + " " + needs[1] + " " + needs[2] + " " + needs[3] + " " + needs[4] + " " + needs[5]);
            role.CloseWindow();
            return TaskResult.Finished;
        }



        private EquipmentAttrType GetEquipmentType(int x1, int y1, int x2, int y2)
        {
            int intX, intY;
            int result = Dm.FindPic(x1, y1, x2, y2, @"\bmp\攻击.bmp|\bmp\防御.bmp|\bmp\掌控.bmp|\bmp\血量.bmp|\bmp\强防.bmp|\bmp\强壮.bmp|\bmp\强攻.bmp|", "404040", 0.6, 0, out intX, out intY);
            return (EquipmentAttrType)result;
        }




        private Tuple<bool, EquipmentAttrType> IsSameEequipmentType()
        {
            EquipmentAttrType type1 = EquipmentAttrType.未知类型, type2 = EquipmentAttrType.未知类型, type3 = EquipmentAttrType.未知类型;
            Delegater.WaitTrue(() =>
            {
                type1 = GetEquipmentType(566, 318, 637, 393);
                type2 = GetEquipmentType(634, 315, 703, 400);
                type3 = GetEquipmentType(701, 315, 776, 408);
                if (type1 != EquipmentAttrType.未知类型 && type2 != EquipmentAttrType.未知类型 && type3 != EquipmentAttrType.未知类型)
                {
                    Dm.DebugPrint("属性：" + type1.ToString() + " " + type2.ToString() + " " + type3.ToString());
                    return true;
                }
                return false;
            });
            if (type1 == type2 && type2 == type3)
            {
                Dm.DebugPrint("所有类型相同！" + type1.ToString());
                return new Tuple<bool, EquipmentAttrType>(true, type1);
            }
            return new Tuple<bool, EquipmentAttrType>(false, type1);
        }
        /// <summary>
        /// 获取紫装类型
        /// </summary>
        /// <returns></returns>
        private EquipmentType GetEquipmentType()
        {
            string ocr = Dm.Ocr(645, 121, 787, 168, "AB5BC6-25142B", 0.8);
            // Dm.DebugPrint("装备类型为：" + ocr);
            if (ocr == "")
            {
                Dm.DebugPrint("未能识别装备类型.");
                return EquipmentType.未知类型;
            }
            if (ocr.Contains("双枪"))
                return EquipmentType.麒麟双枪;
            if (ocr.Contains("麒麟") && !ocr.Contains("双枪"))
                return EquipmentType.麒麟;
            if (ocr.Contains("三昧纯阳铠"))
                return EquipmentType.三昧纯阳铠;
            if (ocr.Contains("蝶凤舞阳"))
                return EquipmentType.蝶凤舞阳;
            if (ocr.Contains("伏龙帅印"))
                return EquipmentType.伏龙帅印;
            if (ocr.Contains("蟠龙华盖"))
                return EquipmentType.蟠龙华盖;
            return EquipmentType.未知类型;
        }
        private TaskResult RunStep5(TaskContext context)
        {
            Role role = (Role)context.Role;
            List<套装> tempTaozhuangList = role.TaozhuangList;
            Dictionary<string, List<string>> dictCount = new Dictionary<string, List<string>>();
            dictCount.Add("麒麟双枪", new List<string>());
            dictCount.Add("麒麟", new List<string>());
            dictCount.Add("三昧纯阳铠", new List<string>());
            dictCount.Add("蝶凤舞阳", new List<string>());
            dictCount.Add("伏龙帅印", new List<string>());
            dictCount.Add("蟠龙华盖", new List<string>());
            foreach (var item in tempTaozhuangList)
            {
                if (item.麒麟双枪.IsHave == false)
                    dictCount["麒麟双枪"].Add(item.麒麟双枪.类型.ToString());
                if (item.麒麟.IsHave == false)
                    dictCount["麒麟"].Add(item.麒麟.类型.ToString());
                if (item.三昧纯阳铠.IsHave == false)
                    dictCount["三昧纯阳铠"].Add(item.三昧纯阳铠.类型.ToString());
                if (item.蝶凤舞阳.IsHave == false)
                    dictCount["蝶凤舞阳"].Add(item.蝶凤舞阳.类型.ToString());
                if (item.伏龙帅印.IsHave == false)
                    dictCount["伏龙帅印"].Add(item.伏龙帅印.类型.ToString());
                if (item.蟠龙华盖.IsHave == false)
                    dictCount["蟠龙华盖"].Add(item.蟠龙华盖.类型.ToString());
            }
            Delegater.WaitTrue(() =>
            {
                string points = Dm.FindPicEx(98, 120, 556, 513, @"\bmp\星星3.bmp", "303030", 0.8, 0);
                // Debug.WriteLine(points);
                if (points == "")
                {
                    return true;
                }
                string[] t = points.Split('|');
                foreach (var item in t)
                {
                    string[] p = item.Split(',');
                    Dm.Delay(1000);
                    Dm.MoveToClick(int.Parse(p[1]), int.Parse(p[2]));
                    //  Dm.DebugPrint("点击坐标：" + int.Parse(p[1]) + " " + int.Parse(p[2]));
                    Dm.Delay(1000);
                    if (Dm.IsExistPic(707, 382, 734, 404, @"\bmp\星星1.bmp", 0.8, false))
                    {
                        // Dm.DebugPrint("该装备为紫装！");
                        if (Dm.IsExistPic(792, 380, 821, 401, @"\bmp\星星1.bmp", 0.8, false))
                        {
                            //  Dm.DebugPrint("该装备已经4星！");
                            continue;
                        }
                        var etype = GetEquipmentType();
                        Dm.DebugPrint("当前装备类型为：" + etype.ToString());
                        if (etype == EquipmentType.未知类型)
                            continue;
                        else
                        {

                            int count = tempTaozhuangList.Count(x => ((Equipment)x.GetType().GetProperty(etype.ToString()).GetValue(x)).IsHave == true);
                            if (count == 10)
                            {
                                Dm.DebugPrint(etype.ToString() + "都已洗完！");
                                continue;
                            }
                            else
                                Dm.DebugPrint(etype.ToString() + "剩下【" + (10 - count) + "】件未洗.");
                            var hs = new HashSet<string>(dictCount[etype.ToString()]);
                            if (hs.Count == 1)
                            {
                                Dm.DebugPrint(etype.ToString() + "剩下一个属性未洗,跳过!");
                                continue;
                            }

                        }
                        Delegater.WaitTrue(() =>
                            {
                                Dm.MoveToClick(631, 448);
                                Dm.Delay(500);
                                if (Dm.IsExistPic(379, 213, 475, 255, @"\bmp\隐藏技能.bmp", 0.8, false))
                                {
                                    EquipmentAttrType atttype = EquipmentAttrType.未知类型;
                                    Delegater.WaitTrue(() =>
                                    {
                                        atttype = GetEquipmentType(781, 315, 861, 402);
                                        if (atttype != EquipmentAttrType.未知类型)
                                            return true;
                                        return false;
                                    });
                                    var eqtype = GetEquipmentType();
                                    Dm.DebugPrint("装备【" + eqtype.ToString() + "】洗出属性【" + atttype + "】");
                                    if (eqtype == EquipmentType.未知类型)
                                        ClosePopup(550, 361);//点击点取消
                                    else
                                    {
                                        int count = tempTaozhuangList.Count(x => ((Equipment)x.GetType().GetProperty(eqtype.ToString()).GetValue(x)).IsHave == true);
                                        套装 taozhuang = tempTaozhuangList.FirstOrDefault(x => ((Equipment)x.GetType().GetProperty(eqtype.ToString()).GetValue(x)).类型 == atttype && ((Equipment)x.GetType().GetProperty(etype.ToString()).GetValue(x)).IsHave == false);
                                        if (taozhuang != null)
                                        {
                                            ((Equipment)taozhuang.GetType().GetProperty(eqtype.ToString()).GetValue(taozhuang)).IsHave = true;

                                            string temp = "", temp2 = "";
                                            foreach (var it in tempTaozhuangList)
                                            {
                                                var a = (Equipment)it.GetType().GetProperty(eqtype.ToString()).GetValue(it);
                                                if (a.IsHave == false)
                                                    temp = temp + a.类型.ToString() + " ";
                                                if (a.IsHave == true)
                                                    temp2 = temp2 + a.类型.ToString() + " ";
                                            }
                                            dictCount[etype.ToString()].Remove(atttype.ToString());
                                            Dm.DebugPrint("属性【" + atttype.ToString() + "】是装备【" + etype.ToString() + "】需要的属性.  " + eqtype.ToString() + "已有属性：" + temp2 + ",还剩下属性未洗：" + temp + "  剩下件数未洗：" + (10 - count - 1));
                                            ClosePopup(550, 361);//点击点取消
                                            return true;
                                        }
                                        else
                                        {
                                            if (count == 10)
                                            {
                                                Dm.DebugPrint(eqtype.ToString() + "都已洗完！");
                                                return true;
                                            }
                                            else
                                            {
                                                string temp = "", temp2 = "";
                                                foreach (var it in tempTaozhuangList)
                                                {
                                                    var a = (Equipment)it.GetType().GetProperty(eqtype.ToString()).GetValue(it);
                                                    if (a.IsHave == false)
                                                        temp = temp + a.类型.ToString() + " ";
                                                    if (a.IsHave == true)
                                                        temp2 = temp2 + a.类型.ToString() + " ";
                                                }
                                                Dm.DebugPrint("属性【" + atttype.ToString() + "】不是装备【" + etype.ToString() + "】需要的属性.需要属性：【" + temp + "】");
                                            }
                                        }
                                        ClosePopup(409, 362);//点击确定
                                    }

                                }
                                return false;
                            });

                    }
                    Dm.Delay(1000);
                }
                Dm.Swipe(515, 438, 515, 320, 50);
                Dm.Delay(1000);
                return false;
            });
            return TaskResult.Finished;
        }

        private void ClosePopup(int x, int y)
        {
            Delegater.WaitTrue(() =>
            {
                if (Dm.IsExistPic(379, 213, 475, 255, @"\bmp\隐藏技能.bmp", 0.8, false))
                {
                    Dm.MoveToClick(x, y); //点确定取消
                                          // Dm.DebugPrint("点击坐标：" + x + " " + y);
                    Dm.Delay(3000);
                    if (!Dm.IsExistPic(379, 213, 475, 255, @"\bmp\隐藏技能.bmp", 0.8, false))
                        return true;
                }
                return false;
            });
            Dm.Delay(1000);
        }
        private TaskResult RunStep4(TaskContext context)
        {
            Role role = (Role)context.Role;
            Delegater.WaitTrue(() => Dm.FindPicAndClick(856, 448, 958, 536, @"\bmp\菜单未打开.bmp"),
                               () => Dm.IsExistPic(856, 448, 958, 536, @"\bmp\菜单打开.bmp"), () => Dm.Delay(1000));
            Delegater.WaitTrue(() => role.OpenMenu("装备"),
                              () => role.OpenWindowMenu("商店"), () => Dm.Delay(1000));
            Delegater.WaitTrue(() =>
            {
                Dm.FindStrAndClick(718, 448, 857, 502, "刷新", "86.17.70-5.5.25");
                if (Dm.IsExistPic(283, 192, 668, 411, @"\bmp\金币秒CD.bmp"))
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
            }, () => Dm.Delay(500));
            role.CloseWindow();
            return TaskResult.Finished;
        }


        private TaskResult RunStep2(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;
            if (dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") &&
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
            });
            return TaskResult.Finished;
        }

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            role.OutMessage("打开兵器界面");

            role.OpenMenu("兵器");
            Dm.Delay(2000);
            List<Tuple<int, int>> pointList = new List<Tuple<int, int>>();
            pointList.Add(new Tuple<int, int>(409, 181));
            pointList.Add(new Tuple<int, int>(408, 326));
            pointList.Add(new Tuple<int, int>(408, 471));
            pointList.Add(new Tuple<int, int>(790, 182));
            pointList.Add(new Tuple<int, int>(787, 326));
            pointList.Add(new Tuple<int, int>(785, 470));

            WeaponInfo info = role.GetWeaponInfo();
            if (info != null)
            {
                for (int i = 0; i < info.weapons.Count; i++)
                {
                    while (true)
                    {
                        if(role.Level!=0)
                        {
                           if(!bool.Parse(info.infiniteLv))
                            {
                                if (role.Level== int.Parse(info.weapons[i].lv))
                                    break;  
                            }
                        }
                        else
                        {
                            Dm.DebugPrint("Err:未能识别等级!");
                            return TaskResult.Finished;
                        }
                        if(bool.Parse(info.fullLv))
                        {
                            Dm.DebugPrint("Err:已经全部满级！");
                            role.CloseWindow();
                            return TaskResult.Finished;

                        }
                        //是否最大值
                        if (bool.Parse(info.weapons[i].isMax))
                        {
                            Dm.DebugPrint("位置"+i+"等级已经达到上限");
                            break;
                        }
                       if(info.weapons[i].hasReformBtn!=null)
                        {
                            if(bool.Parse(info.weapons[i].hasReformBtn))
                            {
                                Dm.MoveToClick(493, 452);
                                Dm.Delay(1000);
                                Dm.MoveToClick(493, 452);
                            }
                        }

                        //当前钢数量比升级所需数量大
                        if (int.Parse(info.nowIron) > int.Parse(info.weapons[i].upgradeCost))
                        {
                            Dm.MoveToClick(pointList[i].Item1, pointList[i].Item2);
                            Dm.Delay(200);
                        }
                        else
                        {
                            Dm.DebugPrint("Err:镔铁不足！");
                            role.CloseWindow();
                            return TaskResult.Finished;
                        }
                        info = role.GetWeaponInfo();
                    }

                }

            }
            role.CloseWindow();

            return TaskResult.Finished;

        }
    }
}
