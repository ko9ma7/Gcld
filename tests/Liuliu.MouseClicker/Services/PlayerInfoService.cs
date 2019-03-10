using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Services
{
    public class PlayerInfoService
    {
        DBHelper<PlayerInfo> helper = new DBHelper<PlayerInfo>();
        public void AddOrUpdate(PlayerInfo pi)
        {
            var r = helper.FindList(x => x.PlayerName == pi.PlayerName).FirstOrDefault();
            if (r == null)
                helper.Add(pi);
            else
            {
                r.EquipSuit = pi.EquipSuit;
                r.Exp = pi.Exp;
                r.ExpNeed = pi.ExpNeed;
                r.Gold = pi.Gold;
                r.UGold = pi.UGold;
                r.PlayerLv = pi.PlayerLv;
                
                helper.Update(r);
            }

        }
    }
}
