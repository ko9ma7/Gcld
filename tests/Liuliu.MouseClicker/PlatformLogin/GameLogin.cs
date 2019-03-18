using System.Diagnostics;
using sy07073.mobile.game.sdk.unit;
using System.Text;
using Liuliu.MouseClicker.Contexts;
using System;
using System.Collections.Generic;
using OSharp.Utility.Secutiry;

namespace Liuliu.MouseClicker.PlatformLogin
{
    public class GameLogin
    {
        private string _username;
        private string _password;
        public GameLogin(string username,string password)
        {
            _username = username;
            _password = password;
            loginDict.Add(Platform.楚游_070703sy, _07073syLogin);
        }
        HttpHelper http = new HttpHelper();
        Dictionary<Platform, Func<bool>> loginDict = new Dictionary<Platform, Func<bool>>();
        public bool Login(Platform platform)
        {
            if (loginDict.ContainsKey(platform))
                return loginDict[platform]();
            else
                return false;
        }

        /*Des.decodeValue("xxxx");
         * ZpqEsAkjVvcNjnvmuzMEw9M8pdaVy1nkZ2Ns0IzVYfqtKJYCcNdKn0GwY8w4pwNJUmHSNKsM/PXJgeUlCsmPn/PO34OYMYFd8HTAX3mCS3mSZ/OwREI7j31/dhs7mAu4ZoQeKXuBOWlme8moRj4Z50VXwhHYeMhn
           api=login&gameid=62&password=B7CFC4A5002623CBF4956D04D24210E9&sign=7E4114BF354777D065887FB9BDE6BD24&username=daipf88
           api=login&gameid=62&password=C294B8675900AAEF13F7B85ACFE80377&sign=FE82460C2D594D5403D7021314D4AE8B&username=huang77
        */
        /// <summary>
        /// 07073sy平台登陆
        /// </summary>
        /// <returns></returns>
        private bool _07073syLogin()
        {
            //第一步：向http://sdk.07073sy.com/index.php/SDKv4 post提交
            //api=getgame_uv&gameid=62&sign=5BD1A2DB6E5B32C493143BF9D4CDC1CF
            //sign=md5(api=getgame_uv&gameid=62Ks.V60!3) 参数+signkey
            string sign = HashHelper.GetMd5("api=getgame_uv&gameid=62" + Constant.signKey).ToUpper();
            HttpItem item = new HttpItem()
            {
                URL = "http://sdk.07073sy.com/index.php/SDKv4",
                Method = "post",
                IsToLower = false,  
                Cookie = "",
                Referer = "", 
                Postdata = "data="+Des.encode("api=getgame_uv&gameid=62&sign="+sign),//Post数据
                Timeout = 20000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT6.0)",
                ContentType = "application/x-www-form-urlencoded",
                Allowautoredirect = false, 
                ProxyIp = "",  
                ResultType = ResultType.String
            };
            HttpResult result = http.GetHtml(item);
            
            string html = result.Html;
            //{ "state":1,"msg":"succ","data":{ "v":"1","apk":"http:\/\/d1.07073sy.com:81\/app\/gcld\/gcld.apk","gamename":"\u653b\u57ce\u63a0\u5730"} }
            
            string cookie = result.Cookie;



            return true;
        }

       
    }
    public enum Platform
    {
        楚游_070703sy
    }
}
