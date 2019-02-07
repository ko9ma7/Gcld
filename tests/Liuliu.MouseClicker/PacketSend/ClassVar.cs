using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Liuliu.MouseClicker.PacketSend
{
    class ClassVar
    {
    }

    [DataContract]
    public class CipherCode
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public string tp { get; set; }
        /// <summary>
        /// 密钥?
        /// </summary>
        [DataMember]
        public string public_exponent { get; set; }
        /// <summary>
        /// 获取是否成功
        /// </summary>
        [DataMember]
        public bool success { get; set; }
        /// <summary>
        /// 密钥2
        /// </summary>
        [DataMember]
        public string public_modulus { get; set; }
    }
    [DataContract]
    public class webPersonalInfo
    {
        [DataMember]
        public string latestVisiteOn { get; set; }
        // 
        [DataMember]
        public string playerid { get; set; }

        [DataMember]
        public webGameInfo phistory { get; set; }
    }
    [DataContract]
    public class webLoginInfo
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public string ts { get; set; }

        [DataMember]
        public UserFlag current_user { get; set; }

        /// <summary>
        /// 获取是否成功
        /// </summary>
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public string key { get; set; }
    }
    [DataContract]
    public class UserFlag
    {
        [DataMember]
        public string encryptInfo { get; set; }
    }

    [DataContract]
    public class webGameInfo
    {
        [DataMember]
        public string loginDatetime { get; set; }

        [DataMember]
        public string playerName { get; set; }
        //
        [DataMember]
        public string gameId { get; set; }
        [DataMember]
        public string serverName { get; set; }
        [DataMember]
        public string gameName { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string gameUrl { get; set; }

        //
        [DataMember]
        public string playerId { get; set; }
        [DataMember]
        public int server { get; set; }
        [DataMember]
        public string serverUrl { get; set; }
    }

    [DataContract]
    public class webRole
    {
        [DataMember]
        public int playerId { get; set; }
        [DataMember]
        public int playerLv { get; set; }
        [DataMember]
        public string playerName { get; set; }
        [DataMember]
        public int pic { get; set; }
        [DataMember]
        public int consumLv { get; set; }
        [DataMember]
        public bool isDelete { get; set; }
        [DataMember]
        public int forceId { get; set; }
        [DataMember]
        public int defaultPay { get; set; }
    }

    [DataContract]
    public class webDetailRole
    {
        [DataMember]
        public string serverKey { get; set; }
        [DataMember]
        public int playerId { get; set; }
        [DataMember]
        public int ast { get; set; }
        [DataMember]
        public int playerLv { get; set; }
        [DataMember]
        public string playerName { get; set; }
        [DataMember]
        public string userId { get; set; }
        [DataMember]
        public int forceId { get; set; }
        [DataMember]
        public int gold { get; set; }
        [DataMember]
        public int uGold { get; set; }
        [DataMember]
        public string pkey { get; set; }
        [DataMember]
        public string pkey2 { get; set; }
        [DataMember]
        public bool openTrade { get; set; }
        /// <summary>
        /// 银两
        /// </summary>
        [DataMember]
        public int copper { get; set; }

        [DataMember]
        public int copperMax { get; set; }

        [DataMember]
        public int copperOutput { get; set; }
        /// <summary>
        /// 粮食
        /// </summary>
        [DataMember]
        public int food { get; set; }
        [DataMember]
        public int foodMax { get; set; }
        [DataMember]
        public int foodOutput { get; set; }

        [DataMember]
        public int wood { get; set; }
        [DataMember]
        public int woodMax { get; set; }
        [DataMember]
        public int woodOutput { get; set; }

        [DataMember]
        public int iron { get; set; }
        [DataMember]
        public int ironMax { get; set; }
        [DataMember]
        public int ironOutput { get; set; }


        [DataMember]
        public int exp { get; set; }
        [DataMember]
        public int expNeed { get; set; }// 

        [DataMember]
        public int forces { get; set; }
        [DataMember]
        public int forcesMax { get; set; }// 

        [DataMember]
        public int fbLike { get; set; }// 
        [DataMember]
        public bool inPveBattle { get; set; }
        [DataMember]
        public bool inOccupyBattle { get; set; }
    }
  
}
