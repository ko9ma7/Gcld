using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
  
        public class Items
        {
            public string itemId { get; set; }
            public string name { get; set; }
            public List<RefreshAttribute> refreshAttribute { get; set; }
            public string maxLv { get; set; }
            public string maxSkillNum { get; set; }
            public string copper { get; set; }
            public string intro { get; set; }
            public string pic { get; set; }
            public string lv { get; set; }
            public string quality { get; set; }
            public string suitName { get; set; }
            public string type { get; set; }
            public string price { get; set; }
            public string isGold { get; set; }

            public string maxGeneralNum { get; set; }
            /// <summary>
            /// 当前该装备数量
            /// </summary>
            public string curItemNum { get; set; }
            public string hotDegree { get; set; }
            public string att { get; set; }
            public string locked { get; set; }
            public string unlockCD { get; set; }
            public string bought { get; set; }
            public string isDragonEquip { get; set; }
        }

        public class SpecialCities
        {
            public string cityId { get; set; }
            public string cityName { get; set; }
            public string hasSpecialCity { get; set; }
        }

        public class StoreItem
        {
            public string vipLimit { get; set; }
            public List<Items> items { get; set; }
            /// <summary>
            /// 当前仓库物品数量
            /// </summary>
            public string nowItemNum { get; set; }
            /// <summary>
            /// 仓库上限
            /// </summary>
            public string maxItemNum { get; set; }
            public string refreshCD { get; set; }
            public string cdInRedMinutes { get; set; }
            public string yellowed { get; set; }
            public string intimacyLv { get; set; }
            public string curIntimacy { get; set; }
            public string maxIntimacy { get; set; }
            public string isIntiLimit { get; set; }
            public string isIntiUp { get; set; }
            public string needTips { get; set; }
            public List<SpecialCities> specialCities { get; set; }
        }
    
}
