using Liuliu.ScriptEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liuliu.ScriptEngine.Damo;

namespace Liuliu.MouseClicker
{
    public class Role
    {//
        // 摘要:
        //     获取 登录账号
        string Ac { get; }
        //
        // 摘要:
        //     获取 所在区服
        string Area { get; }
        //
        // 摘要:
        //     获取 当前地图
        string CurrentMap { get; }
        //
        // 摘要:
        //     获取 经验值
        int Empirical { get; }
        //
        // 摘要:
        //     获取 升级经验值
        int EmpiricalMax { get; }


        //
        // 摘要:
        //     获取 是否在城中
        bool InCity { get; }
        //
        // 摘要:
        //     获取 是否在世界
        bool InWorld { get; }

        //
        // 摘要:
        //     获取 等级
        int Level { get; }


        //
        // 摘要:
        //     获取 金币
        decimal Money { get; }

        //
        // 摘要:
        //     获取 角色名
        string Name { get; }
        //
        // 摘要:
        //     获取 任务消息输出，主要用于Liuliu.ScriptEngine.Tasks.TaskBase执行过程中的消息输出
        Action<string> OutMessage { get; }
        //
        // 摘要:
        //     获取 子功能消息输出，主要用于Liuliu.ScriptEngine.Models.IRole的扩展方法的细节消息输出
        Action<string> OutSubMessage { get; }
        //
        // 摘要:
        //     获取 登录密码
        string P { get; }


        //
        // 摘要:
        //     获取 角色所在窗口
        DmWindow Window { get; }

    }
}
