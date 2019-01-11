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
                TcpRow t = allTcp.FirstOrDefault(x => x.RemoteAddress.ToString() == SoftContext.ServerIp && x.RemotePort == 8220 && x.state == ConnectionState.Established);
                if (t.LocalAddress.ToString() == "0.0.0.0" && t.RemoteAddress.ToString() == "0.0.0.0")
                    return "";
                else
                    _key = string.Format("{0}:{1}->{2}:{3}[Receive]", t.RemoteAddress.ToString(), t.RemotePort, t.LocalAddress.ToString(), t.LocalPort);
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
    }
}
