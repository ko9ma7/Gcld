using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    /// <summary>
    /// 宝石
    /// </summary>
    public class Gems
    {
        public string pos { get; set; }
        public string gemId { get; set; }
        public string gemName { get; set; }
        public string gemPic { get; set; }
        public string gemLv { get; set; }
        public string att { get; set; }
        public string def { get; set; }
        public string blood { get; set; }
        public string goodsType { get; set; }
    }
    /// <summary>
    /// 武器
    /// </summary>
    public class Weapons
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pic { get; set; }
        public string type { get; set; }
        public string reformStars { get; set; }
        /// <summary>
        /// 是否有改造按钮
        /// </summary>
        public string hasReformBtn { get; set; }
        /// <summary>
        /// 是否最大值
        /// </summary>
        public string isMax { get; set; }
        public string times { get; set; }
        public string totalTimes { get; set; }
        /// <summary>
        /// 兵器等级
        /// </summary>
        public string lv { get; set; }
        public string open { get; set; }
        public string make { get; set; }
        /// <summary>
        /// 升级花费
        /// </summary>
        public string upgradeCost { get; set; }
        public List<Gems> gems { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 升级后的数值
        /// </summary>
        public string nextvalue { get; set; }
        public string gemStar { get; set; }
        public string gemValue { get; set; }
    }

    public class WeaponInfo
    {   
        /// <summary>
        /// 剩下的封地时间
        /// </summary>
        public string leftFeudTimes { get; set; }
        /// <summary>
        /// 剩下封地次数
        /// </summary>
        public string leftAccFeudNum { get; set; }
        /// <summary>
        /// 当前钢数量
        /// </summary>
        public string gang { get; set; }
        /// <summary>
        /// 钢最大数量
        /// </summary>
        public string gangMaxNum { get; set; }
        /// <summary>
        /// 兵器信息
        /// </summary>
        public List<Weapons> weapons { get; set; }
        /// <summary>
        /// 当前镔铁数量
        /// </summary>
        public string nowIron { get; set; }
        public string buyCost { get; set; }
        public string iron { get; set; }
        public string isOpenTech { get; set; }
        public string weaponRank { get; set; }
        public string canFuse { get; set; }
        /// <summary>
        /// 已经满级
        /// </summary>
        public string fullLv { get; set; }
        public string infiniteLv { get; set; }
        public string totalHighWeaponUpBound { get; set; }
        public string specialId { get; set; }
        public string specialLimit { get; set; }
        public string specialMulti { get; set; }
        public string cd { get; set; }
    }

}
