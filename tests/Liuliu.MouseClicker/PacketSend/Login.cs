using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Liuliu.MouseClicker.PacketSend
{
    public class Login
    {
        public Login()
        {
            m_client = new HttpClient2();
        }
        /// <summary>
        /// Http客户端
        /// </summary>
        private HttpClient2 m_client;
        /// <summary>
        /// 用户名
        /// </summary>
        private string m_uname;
        /// <summary>
        /// 密码
        /// </summary>
        private string m_passwd;
        private webLoginInfo m_lgnInfo;
        private webPersonalInfo m_psInfo;
        /// <summary>
        /// 用户key
        /// </summary>
        private string m_userkey;
        /// <summary>
        /// pkey
        /// </summary>
        private string m_pkey;
        private string m_strServerName;

        #region 属性get set
        public HttpClient2 Client {
            get { return m_client; }
            set { m_client = value; }
        }
        public string Uname
        {
            get { return m_uname; }
            set { m_uname = value; }
        }
     
        public string Passwd
        {
            get { return m_passwd; }
            set { m_passwd = value; }
        }
        public webLoginInfo LgnInfo
        {
            get { return m_lgnInfo; }
            set { m_lgnInfo = value; }
        }

        public webPersonalInfo PsInfo
        {
            get { return m_psInfo; }
            set { m_psInfo = value; }
        }

        public string Userkey
        {
            get { return m_userkey; }
            set { m_userkey = value; }
        }

        public string Pkey
        {
            get { return m_pkey; }
            set { m_pkey = value; }
        }

        public string StrServerName
        {
            get { return m_strServerName; }
            set { m_strServerName = value; }
        }
        #endregion
        /// <summary>
        /// 从Cookie获取UserKey
        /// </summary>
        /// <returns></returns>
        public bool getUserkeyFromCookie()
        {
            m_userkey = m_client.getOneCookieValue2("ticket");
            return true;
        }
        /// <summary>
        /// 从Cookie获取PKey
        /// </summary>
        /// <returns></returns>
        public bool getPkeyFromCookie()
        {
            m_pkey = m_client.getOneCookieValue2("ticket");
            return true;
        }
        /// <summary>
        /// 将DateTime转为Int
        /// </summary>
        /// <returns></returns>
        public static long ConvertDateTimeToInt()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }
        /// <summary>
        /// 登陆游戏
        /// </summary>
        /// <returns></returns>
        public ExcuteState LoginGame()
        {
            ExcuteState exestate = new ExcuteState();
            exestate.State = IdentityCode.Success;
            return exestate;
            try
            {
                #region 网页登陆操作
                string URL = GlobalVal.CenterURL + "/ssoLogin.action?jsoncallback=jsonp1503016397724&funName=getRSAkey";
                string retstr = m_client.DownloadString(URL, string.Empty);
                retstr = retstr.Replace("\r", "").Replace("\n", "");
                string jsontext = Regex.Match(retstr, "\\((?<value>.*?)\\)").Groups["value"].Value;
                CipherCode cipher = (CipherCode)JsonManager.JsonToObject(jsontext, typeof(CipherCode));
                if (cipher == null)
                {
                    exestate.Description = "json转化为对象失败,json=" + jsontext;
                    return exestate;
                }

                ScriptEngine engine = new ScriptEngine();
                string scriptpath = AppDomain.CurrentDomain.BaseDirectory + "\\RSA_min.js";
                bool bSuccess = engine.LoadScriptFromFile(scriptpath);
                if (!bSuccess)
                {
                    exestate.Description = ("加载脚本失败！脚本路径=" + scriptpath);
                    return exestate;
                }
                //object retobj = engine.Eval(ScriptLanguage.JavaScript,
                //    "RSAKeyPair(\"233AB\", \"\", \"1234566666\")", engine.Functionbody);

                List<object> lst = new List<object>();
                lst.Add(cipher.public_exponent);
                lst.Add(cipher.public_modulus);
                lst.Add(cipher.tp);
                lst.Add(m_passwd);

                object token = engine.EvalValue("getToken", lst, engine.Functionbody);
                string stoken = (string)token;
                long timeticks = ConvertDateTimeToInt();
                URL = GlobalVal.CenterURL + 
                    string.Format("/ssoLogin.action?jsoncallback=jsonp{2}&funName=indexLogin&username={0}&token={1}&remember=true",
                    m_uname, stoken, timeticks);
                retstr = m_client.DownloadString(URL, string.Empty);

                jsontext = Regex.Match(retstr, "\\((?<value>.*?)\\)").Groups["value"].Value;
                webLoginInfo info = (webLoginInfo)JsonManager.JsonToObject(jsontext, typeof(webLoginInfo));
                if (info == null)
                {
                    exestate.Description = "json转化为对象失败2,json=" + jsontext;
                    return exestate;
                }
                if (!info.success)
                {
                    return exestate;
                }

                // 获取个人信息
                URL = GlobalVal.LgnURL + "/html/server/ssoLogin.xhtml";
                string postdata = string.Format("ts={0}&key={1}&userJson=%7B%22encryptInfo%22%3A%22{2}%22%7D&isgameLogin=true", 
                    info.ts, info.key, info.current_user.encryptInfo);

                retstr = m_client.Post(URL, string.Empty, postdata);

                webPersonalInfo gameinfo = (webPersonalInfo)JsonManager.JsonToObject(retstr, typeof(webPersonalInfo));
                m_psInfo = gameinfo;
                jsontext = Regex.Match(retstr, "\\[(?<value>.*?)\\]").Groups["value"].Value;
                List<webGameInfo> ginfo = (List<webGameInfo>)JsonManager.JsonToObject("["+jsontext+"]", typeof(List<webGameInfo>));
                m_psInfo.phistory = ginfo[0];
                m_strServerName = ginfo[0].serverName;

                // 快速登录
                URL = GlobalVal.LgnURL + "/quick.xhtml?gid=gcld";
                m_client.ResponseHeaderData = "Location";
                m_client.DownloadString(URL, string.Empty);
                string jumpURL = m_client.ResponseHeaderData;
                if (string.IsNullOrEmpty(jumpURL))
                {
                    exestate.Description = "获取登录服务器失败";
                    return exestate;
                }

                retstr = m_client.DownloadString(jumpURL, string.Empty);
                if (string.IsNullOrEmpty(retstr))
                {
                    exestate.Description = "获取登录服务器失败2,URL="+jumpURL;
                    return exestate;
                }

                jumpURL = Regex.Match(retstr, "frame src=\"(?<value>.*?)\" name=\"gameFrame").Groups["value"].Value;
                if (string.IsNullOrEmpty(jumpURL))
                {
                    exestate.Description = "获取登录服务器失败3，Page="+retstr;
                    return exestate;
                }

                retstr = m_client.DownloadString(jumpURL, string.Empty);
                if (string.IsNullOrEmpty(retstr))
                {
                    exestate.Description = "获取登录服务器失败4,URL=" + jumpURL;
                    return exestate;
                }
                jumpURL = Regex.Match(retstr, "window.location.href = \"(?<value>.*?)\"").Groups["value"].Value;
                GlobalVal.ServerURL = jumpURL.Substring(0, jumpURL.IndexOf("/root"));
                GlobalVal.CmdURL = GlobalVal.ServerURL + "/root/gateway.action?command=";
                if (string.IsNullOrEmpty(jumpURL))
                {
                    exestate.Description = "获取登录服务器失败5，Page=" + retstr;
                    return exestate;
                }

                retstr = m_client.DownloadString(jumpURL, string.Empty);
                if (retstr == "{\"state\":1,\"data\":1}")
                    exestate.State = IdentityCode.Success;
                else
                    exestate.Description = "获取登录服务器失败6，retstr="+retstr;
                //{
                //    exestate.State = IdentityCode.Success;
                //    m_lgnInfo = info;
                //}
                // = engine.Run("encryptedString", oblist, engine.Functionbody);
                #endregion
            }
            catch (Exception ex)
            {
                exestate.Description = ex.Message + "\r\n" + ex.StackTrace;
                Debug.WriteLine(exestate.Description);
            }

            return exestate;
        }
    }
    /// <summary>
    /// 执行状态
    /// </summary>
    public class ExcuteState
    {
        public ExcuteState()
        {
            m_State = IdentityCode.Fail;
            m_description = "初始化";
        }
        /// <summary>
        /// 认证状态
        /// </summary>
        IdentityCode m_State;
        /// <summary>
        /// 描述
        /// </summary>
        object m_description;
        /// <summary>
        /// 返回信息
        /// </summary>
        object m_retinfo;


        public IdentityCode State
        {
            get { return m_State; }
            set { m_State = value; }
        }
       
        public object Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        public object Retinfo
        {
            get { return m_retinfo; }
            set { m_retinfo = value; }
        }
    }
    public enum IdentityCode
    {
        /// <summary>
        /// 认证失败
        /// </summary>
        Fail,
        /// <summary>
        /// 认证成功
        /// </summary>
        Success,
        /// <summary>
        /// 出现异常
        /// </summary>
        Exception
    };
}
