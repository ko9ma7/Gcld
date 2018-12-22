using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class Notifications
    {
        public static readonly string AccountFlyout = Guid.NewGuid().ToString();
        public static readonly string AccountViewModel = Guid.NewGuid().ToString();
        public static readonly string MainCommandViewModel = Guid.NewGuid().ToString();
        public static readonly string MemHelperFlyout = Guid.NewGuid().ToString();
        public static readonly string MemHelperViewModel = Guid.NewGuid().ToString();

    }
}
