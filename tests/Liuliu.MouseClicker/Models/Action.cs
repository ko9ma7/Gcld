using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    /// <summary>
    /// 动作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RoleAction
    {   /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public Data data { get; set; }

    }
    public class RefreshAttribute
    {
    
        /// <summary>
        /// 属性类型
        /// </summary>
        public string attType { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string attrName { get; set; }
        /// <summary>
        /// 属性等级
        /// </summary>
        public string attValue { get; set; }
        /// <summary>
        /// 技能图片
        /// </summary>
        public string skillPic { get; set; }
        /// <summary>
        /// 属性介绍
        /// </summary>
        public string attIntro { get; set; }
        /// <summary>
        /// 基本介绍
        /// </summary>
        public string baseAttribute { get; set; }
    }
    /// <summary>
    /// 装备
    /// </summary>
    public class Equips
    {
        [JsonIgnore]
        public bool IsSameType
        {
            get {
                if(refreshAttribute!=null&& refreshAttribute.Count>=3)
                     return refreshAttribute[0].attType == refreshAttribute[1].attType &&
                              refreshAttribute[0].attType == refreshAttribute[2].attType;
                return false;
                }
        }
        /// <summary>
        /// 装备等级
        /// </summary>
        public string lv { get; set; }
        /// <summary>
        /// 装备品质
        /// </summary>
        public string quality { get; set; }
        /// <summary>
        /// 装备ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 装备属性
        /// </summary>
        public string attr { get; set; }
        /// <summary>
        /// 装备名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 装备图片
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 装备类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        ///装备属性最大等级
        /// </summary>
        public string maxLv { get; set; }
        /// <summary>
        /// 装备拥有武将
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 武将品质
        /// </summary>
        public string generalQuality { get; set; }
        /// <summary>
        /// 装备刷新属性
        /// </summary>
        public List<RefreshAttribute> refreshAttribute { get; set; }
        /// <summary>
        ///最大技能数量
        /// </summary>
        public string maxSkillNum { get; set; }
        /// <summary>
        /// 装备售价
        /// </summary>
        public string copper { get; set; }
        /// <summary>
        /// 铁
        /// </summary>
        public string iron { get; set; }
        [JsonIgnore]
        public bool IsBelong { get; set; }
    }
    public class Message
    {
        public string msg { get; set; }
    }
    public class Data
    {
        public Message message;

        public List<Equips> equips { get; set; }
    }

    public class RootObject
    {
        public RoleAction action { get; set; }
    }
}
