using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    public class WearEquip
    {

            public string generalId { get; set; }
            public string generalName { get; set; }
            public string gQuality { get; set; }
            public string type { get; set; }
            public string vId { get; set; }
            public string lv { get; set; }
            public string attribute { get; set; }
            public string quality { get; set; }
            public string itemName { get; set; }
            public List<RefreshAttribute> refreshAttribute { get; set; }
            public string maxLv { get; set; }
            public string maxSkillNum { get; set; }
            public string copper { get; set; }
            public string pic { get; set; }
    }
}
