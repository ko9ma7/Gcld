using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models.Enums
{
    [Flags]
    public enum EquipSuitEnum
    {
        None=0,
        青龙套装 = 1,
        白虎套装 = 2,
        朱雀套装 = 4,
        鲮鲤套装 = 8,
        玄武套装 = 16,
        霸下套装 = 32,
        驱虎套装 = 64,
        烛龙套装 = 128,
        凤凰套装 = 512,
        灵龟套装 = 1024,
        真烛龙套装=129,
        真霸下套装=48,
        真驱虎套装=66,
        真灵龟套装=1032,
        真凤凰套装=516,
    }
}
