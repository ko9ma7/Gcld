using System.Diagnostics;
using sy07073.mobile.game.sdk.unit;
using System.Text;
using Liuliu.MouseClicker.Contexts;
using System;
using System.Collections.Generic;
using OSharp.Utility.Secutiry;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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
            JObject jo = (JObject)JsonConvert.DeserializeObject(html);
            string state = jo["state"].ToString();
            string msg = jo["msg"].ToString();
            string data = jo["data"].ToString();
            if (state!="1")
            {
                Debug.WriteLine("登录出错:" + state + " " + Unicode2String(msg));
                return false;
            }
            else
            {
                Debug.WriteLine("第一步成功，data=" + data);
            }
            //第二步：向http://sdk.07073sy.com/index.php/SDKv4 post提交
            //api=login&gameid=62&password=B7CFC4A5002623CBF4956D04D24210E9&sign=7E4114BF354777D065887FB9BDE6BD24&username=daipf88
            //sign=md5(api=login&gameid=62&password=B7CFC4A5002623CBF4956D04D24210E9&username=daipf88Ks.V60!3) 参数+signkey
            string pMd5 = HashHelper.GetMd5(_password).ToUpper();
            string sign2 = HashHelper.GetMd5(string.Format("api=login&gameid=62&password={0}&username={1}{2}",pMd5,_username,Constant.signKey)).ToUpper();
            string url = "http://sdk.07073sy.com/index.php/SDKv4";
            string postData = "data=" + Des.encode(string.Format("api=login&gameid=62&password={0}&sign={1}&username={2}", pMd5,sign2,_username));
            HttpResult result2 = http.GetHtml(GetHttpItem(url, postData));
            string html2 = result2.Html;
            
            JObject jo2 = (JObject)JsonConvert.DeserializeObject(html2);
            string state2 = jo2["state"].ToString();
            string msg2 = jo2["msg"].ToString();
            string data2 = jo2["data"].ToString();
            if (state != "1")
            {
                Debug.WriteLine("登录出错:" + state2 + " " + Unicode2String(msg));
                return false;
            }
            else
            {
                Debug.WriteLine("第二步成功，data=" + data2);
            }


            return true;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Unicode2String(string str)
        {
            var regex = new Regex(@"\\u(\w{4})");

            string result = regex.Replace(str, delegate (Match m)
            {
                string hexStr = m.Groups[1].Value;
                string charStr = ((char)int.Parse(hexStr, System.Globalization.NumberStyles.HexNumber)).ToString();
                return charStr;
            });

            return result;
        }

        public HttpItem GetHttpItem(string url,string postData)
        {
            HttpItem item = new HttpItem()
            {
                URL = url,
                Method = "post",
                IsToLower = false,
                Cookie = "",
                Referer = "",
                Postdata = postData,//Post数据
                Timeout = 20000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT6.0)",
                ContentType = "application/x-www-form-urlencoded",
                Allowautoredirect = false,
                ProxyIp = "",
                ResultType = ResultType.String
            };
            return item;
        }

    }
    public enum Platform
    {
        楚游_070703sy
    }
}
