using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.ScriptEngine.Tasks
{
    /// <summary>
    /// 自动登录
    /// </summary>
    public abstract class AutoLogin
    {
        /// <summary>
        /// 自动登录
        /// </summary>
        public AutoLogin()
        {

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public abstract TaskResult Login();
    }
}
