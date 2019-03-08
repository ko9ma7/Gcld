using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models.Entities
{
    public class PlayerInfo
    {
        public int Id { get; set; }
       
       // public Conuntry Conuntry { get; set; }
        public string ServerId { get; set; }
        public string ServerName { get; set; }
        public string CreateTime { get; set; }
       // public string vId { get; set; }
        public string PlayerId { get; set; }
       // public string ast { get; set; }
        public string PlayerLv { get; set; }
        public string PlayerName { get; set; }
        public string UserId { get; set; }
       // public string yx { get; set; }
       // public string forceId { get; set; }
       // public string pic { get; set; }
        public string Gold { get; set; }
        public string UGold { get; set; }
        public string VipLv { get; set; }
       
        public string Exp { get; set; }
        public string ExpNeed { get; set; }


       // public string forces { get; set; }
       // public string forcesMax { get; set; }
        //public string fbLike { get; set; }
        //public string inPveBattle { get; set; }
       // public string inOccupyBattle { get; set; }


        public virtual ICollection<EquipmentSuit> EquipmentSuitList { get; set; }
    }

    public enum Conuntry
    {
        魏国,
        蜀国,
        吴国
    }
}
