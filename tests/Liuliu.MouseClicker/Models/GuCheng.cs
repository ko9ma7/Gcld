using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    /// <summary>
    /// 剩余步骤
    /// </summary>
    public class LeftSteps
    {
        /// <summary>
        /// 骰子点数
        /// </summary>
        public string dice { get; set; }
        /// <summary>
        /// 还剩下的步数
        /// </summary>
        public string leftSteps { get; set; }
    }

    /// <summary>
    /// 移动信息
    /// </summary>
    public class MoveInfo
    {
        /// <summary>
        /// 移动路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 剩余步数
        /// </summary>
        public string leftSteps { get; set; }
        /// <summary>
        /// 是否终点捡箱子
        /// </summary>
        public string canPickBox { get; set; }
        /// <summary>
        /// 完成百分比
        /// </summary>
        public string percentage { get; set; }
    }
    /// <summary>
    /// 城市
    /// </summary>
    public class Cities
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public string cityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// 城市地形
        /// </summary>
        public string cityTerrian { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        public string terminal { get; set; }
    }
    /// <summary>
    /// 奖励
    /// </summary>
    public class Rewards
    {
        /// <summary>
        /// 奖励类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 奖励数量
        /// </summary>
        public string value { get; set; }
    }

    public class Roads
    {
        public string boxId { get; set; }
        public string startId { get; set; }
        public string endId { get; set; }
        public string type { get; set; }
        public List<Rewards> rewards { get; set; }
        public string hasPicked { get; set; }
    }

    public class Lv2Reward
    {
        public string type { get; set; }
        public string value { get; set; }
        public string name { get; set; }
    }

    public class Maps
    {
        /// <summary>
        /// 地图ID
        /// </summary>
        public string mapId { get; set; }
        public string pic { get; set; }
        /// <summary>
        /// 地图名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        public string open { get; set; }
        /// <summary>
        /// 地图位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 剩下的步数
        /// </summary>
        public string leftSteps { get; set; }
        public string todayTimes { get; set; }
        public string canPickBox { get; set; }
        public string mapLv { get; set; }
        public string mapGold { get; set; }
        /// <summary>
        /// 地图数据列表
        /// </summary>
        public List<Cities> cities { get; set; }
        /// <summary>
        /// 地图路径列表
        /// </summary>
        public List<Roads> roads { get; set; }
        /// <summary>
        /// 奖励
        /// </summary>
        public List<Lv2Reward> lv2Reward { get; set; }
        public string percentage { get; set; }
    }

    public class AncientCity
    {
        public string leftTime { get; set; }
        public string totalTime { get; set; }
        /// <summary>
        /// 每次花费金币
        /// </summary>
        public string timeGold { get; set; }
        public string goldTime { get; set; }
        public string totalPercentage { get; set; }
        public string leftBox { get; set; }
        public string nowBoxNum { get; set; }
        public string canRestart { get; set; }
        public string restartGold { get; set; }
        public string mapLv { get; set; }
        public string allMapOver { get; set; }
        /// <summary>
        /// 地图数据
        /// </summary>
        public List<Maps> maps { get; set; }
        public string percent1 { get; set; }
        public string percent2 { get; set; }
        public string maxTime { get; set; }
    }








}
