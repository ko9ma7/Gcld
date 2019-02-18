using Liuliu.MouseClicker.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{

    public class GameHelper
    {
        private int _noxVMHandlePid = 0;
        public GameHelper(int noxVMHandlePid)
        {
            _noxVMHandlePid = noxVMHandlePid;
        }

        private string _key = "";
        public string CaptureKey
        {
            get
            {
                TcpRow[] allTcp = NetProcess.GetTcpConnections(_noxVMHandlePid);
                foreach (var item in allTcp)
                {
                    if(item.RemoteAddress.ToString() == SoftContext.ServerIp && item.RemotePort == 8220 && item.state == ConnectionState.Established)
                    {
                        if (item.LocalAddress.ToString() == "0.0.0.0" && item.RemoteAddress.ToString() == "0.0.0.0")
                            continue;
                        else
                        {
                            _key = string.Format("{0}:{1}->{2}:{3}[Receive]", item.RemoteAddress.ToString(), item.RemotePort, item.LocalAddress.ToString(), item.LocalPort);
                            break;
                        }
                    }
                }
                return _key;
            }
        }

        /// <summary>
        ///通过字典Key获取Json对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public dynamic GetData(string key)
        {
            Debug.WriteLine("获取数据key：" + CaptureKey+key);

            if (SoftContext.CommandList.ContainsKey(CaptureKey + key))
                return SoftContext.CommandList[CaptureKey + key];
            return null;
        }
        /// <summary>
        /// 获取当前角色信息
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            var playInfo = GetData(Const.ROLE_GET_INFO);
            if (playInfo != null)
            {
                JObject jObject = playInfo.action.data.player;
                Player player = jObject.ToObject<Player>();
                Debug.WriteLine(player.serverId + " " + player.serverName + " " + player.playerName + " " + player.playerId + " " + player.playerLv);
                return player;
            }
            return null;
        }

        /// <summary>
        /// 获取商店当前物品
        /// </summary>
        /// <returns></returns>
        public StoreItem GetStoreItem()
        {
            var dy = GetData(Const.REFRESH_SHOP_ITEMS);
            if (dy != null)
            {
                JObject j = dy.action.data;
                return j.ToObject<StoreItem>(); 
            }
            else
            {
                dy=GetData(Const.GET_SHOP_ITEMS);
                if (dy != null)
                {
                    JObject j = dy.action.data;
                    return j.ToObject<StoreItem>();
                }
            }
            return null;
        }
        
        public WeaponInfo GetWeaponInfo()
        {
            var dy = GetData(Const.WEAPON_OPEN_GETWEAPONINFO);
            if (dy != null)
            {
                JObject jObject = dy.action.data;
                WeaponInfo wi = jObject.ToObject<WeaponInfo>();
              
                return wi;
            }
            return null;
        }
        

        public MoveInfo GetMoveInfo()
        {
            return (MoveInfo)GetObject<MoveInfo>(Const.ANCIENT_CASTLE_MOVE);
        }
        public AncientCity GetAncientCity()
        {
            return (AncientCity)GetObject<AncientCity>(Const.ACTIVITY_COMMON);
        }
        public LeftSteps GetLeftSteps()
        {
            return (LeftSteps)GetObject<LeftSteps>(Const.ANCIENT_CASTLE_DICE);
        }
        public object GetObject<T>(string cons)
        {
            var dy = GetData(cons);
            if (dy != null)
            {
                JObject jObject = dy.action.data;
                object obj = jObject.ToObject<T>();
                return obj;
            }
            return null;
        }

      

    }
}
