using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models.Entities
{
    public class EquipmentSuit
    {
        public int Id { get; set; }
        public string SuitName { get; set; }
        public int PlayerInfoId { get; set; }
        public virtual PlayerInfo PlayerInfo { get; set; }
    }
}
