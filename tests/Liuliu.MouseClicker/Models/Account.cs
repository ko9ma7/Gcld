using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    public class Account
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        public Platform Platform { get; set; }
        /// <summary>
        /// 是否已经执行完
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// 是否正在工作
        /// </summary>
        public bool IsWorking { get; set; }
        /// 是否自动登陆
        /// </summary>
        public bool IsAutoLogin { get; set; }
    }

    public enum Platform
    {
        飞流,
        楚游,
        九游,
        TT,
        偶玩,
        豌豆荚,
        百度
    }
}
