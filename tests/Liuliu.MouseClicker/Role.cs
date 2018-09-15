using Liuliu.ScriptEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liuliu.ScriptEngine.Damo;

namespace Liuliu.MouseClicker
{
    public class Role:IRole
    {//
        public int HealthPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int HealthPointMax
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool InSafePlace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAlive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int MagicPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int MagicPointMax
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal MoneyInBag
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal MoneyInRepertory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double PointX
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double PointY
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Sociaty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SociatyPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Vocation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal Yuanbao
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IRole.Ac
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // 摘要:
        //     获取 登录账号
        string Ac { get; }

        string IRole.Area
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 所在区服
        string Area { get; }

        string IRole.CurrentMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 当前地图
        string CurrentMap { get; }

        int IRole.Empirical
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 经验值
        int Empirical { get; }

        int IRole.EmpiricalMax
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 升级经验值
        int EmpiricalMax { get; }

        bool IRole.InCity
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        //
        // 摘要:
        //     获取 是否在城中
        bool InCity { get; }
        //
        // 摘要:
        //     获取 是否在世界
        bool InWorld { get; }

        int IRole.Level
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 等级
        int Level { get; }


        //
        // 摘要:
        //     获取 金币
        decimal Money { get; }

        string IRole.Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 角色名
        string Name { get; }

        Action<string> IRole.OutMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 任务消息输出，主要用于Liuliu.ScriptEngine.Tasks.TaskBase执行过程中的消息输出
        Action<string> OutMessage { get; }

        Action<string> IRole.OutSubMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 子功能消息输出，主要用于Liuliu.ScriptEngine.Models.IRole的扩展方法的细节消息输出
        Action<string> OutSubMessage { get; }

        string IRole.P
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // 摘要:
        //     获取 登录密码
        string P { get; }

        DmWindow IRole.Window
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        //
        // 摘要:
        //     获取 角色所在窗口
        DmWindow Window { get; }

        public bool IsInPos(double x, double y, double alw = 0.2)
        {
            throw new NotImplementedException();
        }

        public bool IsMoving(int mis = 1000)
        {
            throw new NotImplementedException();
        }
    }
}
