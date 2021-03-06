﻿using System;
using System.Diagnostics;
using System.Threading;

namespace Liuliu.ScriptEngine.Damo
{
    /// <summary>
    /// 大漠插件<see cref="DmPlugin"/>扩展操作
    /// </summary>
    public static class DmPluginExtensions
    {
        /// <summary>
        /// 查找区域是否存在指定图片
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="picname"></param>
        /// <param name="sim"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static bool IsExistPic(this DmPlugin _dm,int x1,int y1,int x2,int y2,string picname,double sim=0.8,bool isShow=true)
        {
            int intX, intY;
            _dm.FindPic(x1, y1, x2, y2, picname, "202020", sim, 0, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                _dm.DebugPrint("存在图片【"+ picname + "】!",isShow);
                return true;
            }
            else
            {
                _dm.DebugPrint("不存在图片【" + picname + "】!",isShow);
                return false;
            }
        }
        /// <summary>
        /// 查找区域是否存在指定图片
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool IsExistStr(this DmPlugin _dm, int x1, int y1, int x2, int y2, string str,string color)
        {
            int intX, intY;
            _dm.FindStr(x1, y1, x2, y2, str, color, 0.8, out intX, out intY);
            if (intX > 0 && intY > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 查找指定区域是否存在图片,存在则点击图片,可设置偏移
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="picname"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static bool FindPicAndClick(this DmPlugin _dm, int x1, int y1, int x2, int y2, string picname,int a=0,int b=0,double sim=0.8)
        {
            int intX, intY;
            _dm.FindPic(x1, y1, x2, y2, picname, "202020",sim, 0, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                _dm.DebugPrint("找图[" + picname + "]成功!"+"坐标:"+intX+" "+intY);
                _dm.MoveToClick(intX+a, intY+b);
                _dm.Delay(50);
                return true;
            }
            _dm.DebugPrint("找图[" + picname + "]失败!");
            return false;
        }
        /// <summary>
        /// 查找指定区域是否存在字,存在则点击字,可设置偏移
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool FindStrAndClick(this DmPlugin _dm, int x1, int y1, int x2, int y2, string str, string color,int a = 0, int b = 0)
        {
            int intX, intY;
            _dm.FindStr(x1, y1, x2, y2, str, color, 0.8, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                //Debug.WriteLine("找字[" + str + "]成功!");
                _dm.MoveToClick(intX + a, intY + b);
                _dm.Delay(50);
                return true;
            }

            Debug.WriteLine("[" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + "找字[" + str + "]失败!");
            return false;
        }
        /// <summary>
        /// 滑动操作
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="mousedelay">鼠标每步延时</param>
        /// <param name="mousestep">鼠标步长</param>
        public static void Swipe(this DmPlugin _dm,int x1,int y1,int x2,int y2,int mousedelay=30,int mousestep=10)
        {
            _dm.EnableRealMouse(1, mousedelay, mousestep);
            _dm.MoveTo(x1, y1);
            _dm.Delay(50);
            _dm.LeftDown();
            _dm.Delay(50);
            _dm.MoveTo(x2, y2);
            _dm.Delay(50);
            _dm.LeftUp();
            _dm.Delay(50);
            _dm.EnableRealMouse(0, mousedelay, mousestep);
        }

        /// <summary>
        /// 查找指定区域是否存在图片,存在则点击图片,直到图片消失
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="picname"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static bool FindPicAndClickClear(this DmPlugin _dm, int x1, int y1, int x2, int y2, string picname, int a = 0, int b = 0,int delay=1000)
        {
            int intX, intY;
            while (true)
            {
              _dm.FindPic(x1, y1, x2, y2, picname, "101010", 0.9, 0, out intX, out intY);
                if (intX > 0 && intY > 0)
                {
                    _dm.MoveToClick(intX + a, intY + b);
                    _dm.Delay(delay);
                    _dm.FindPic(x1, y1, x2, y2, picname, "101010", 0.9, 0, out intX, out intY);
                    if (intX < 0 && intY < 0)
                        return true;
                }
                else
                {
                    return true;
                }
                  
                _dm.Delay(50);
            }
        }
        /// <summary>
        /// 找色并点击
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool FindColorAndClick(this DmPlugin _dm, int x1, int y1, int x2, int y2, string color)
        {
            int intX, intY;
            _dm.FindColor(x1, y1, x2, y2, color,0.9, 0, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                _dm.MoveToClick(intX, intY);
                _dm.Delay(50);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断点(a,b)是否在区域(x1,y1,x2,y2)里
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsInRect(this DmPlugin _dm,int x1,int y1,int x2,int y2,int a,int b)
        {
            return a >= x1 && a <= x2 && b <= y2 && b >= y1;
        }
        /// <summary>
        /// 获取识别到的数字
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <param name="sim"></param>
        /// <returns>-1为获取失败,否则返回正整数</returns>
        public static int GetOcrNumber(this DmPlugin _dm,int x1,int y1,int x2,int y2,string color)
        {
            string ocr = _dm.Ocr(x1, y1, x2, y2, color, 0.78);
            _dm.DebugPrint(ocr);
            _dm.DebugPrint("获取到的数字：" + ocr);
            if (ocr == "")
                return -1;
            int result;
            try
            {
                if (int.TryParse(ocr, out result))
                    return result;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// 获取某处颜色数量,执行某个操作,结束后判断数量是否改变
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <param name="action"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static bool IsChangeColorNum(this DmPlugin _dm,int x1,int y1,int x2,int y2,string color,Action action,double sim=0.9)
        {
            int a=_dm.GetColorNum(x1, y1, x2, y2, color, sim);
            action();
            int b = _dm.GetColorNum(x1, y1, x2, y2, color, sim);
            if (a == b)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 获取某处颜色数量,执行某个操作,执行完后判断数量在某个时间段内是否改变
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <param name="action"></param>
        /// <param name="time"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static bool IsChangeColorNumEx(this DmPlugin _dm, int x1, int y1, int x2, int y2, string color, Action action,long time=2000,double sim = 0.9)
        {
            int a, b;
            a= _dm.GetColorNum(x1, y1, x2, y2, color, sim);
            action();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while(sw.ElapsedMilliseconds<=time)
            {
                b = _dm.GetColorNum(x1, y1, x2, y2, color, sim);
                if (a != b)
                {
                    sw.Stop();
                    break;
                }
            }
            sw.Stop();
            return sw.ElapsedMilliseconds <=time;
        }
        /// <summary>
        /// 获取某个区域相同图片个数
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="picname"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static int GetPicCount(this DmPlugin _dm, int x1, int y1, int x2, int y2, string picname,double sim = 0.8)
        {
            string result=_dm.FindPicEx(x1, y1, x2, y2, picname, "202020", sim, 0);
            if (result == "")
                return 0;
            return result.Split('|').Length;
        }
        /// <summary>
        /// 查找色块并点击
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static bool FindColorBlockAndClick(this DmPlugin _dm,int x1,int y1,int x2,int y2,string color,int count,int width,int height,double sim= 0.9)
        {
            int intX, intY;
            bool result=_dm.FindColorBlock(x1, y1, x2, y2, color, sim, count, width, height, out intX, out intY);
            if(intX>0&&intY>0)
            {
                _dm.MoveToClick(intX, intY);
                _dm.DebugPrint(intX + " " + intY);
                _dm.Delay(50);
            }
            return result;
        }
        /// <summary>
        /// 多点找色并点击
        /// </summary>
        /// <param name="_dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="firstColor"></param>
        /// <param name="offsetColor"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public static bool FindMultiColorAndClick(this DmPlugin _dm,int x1,int y1,int x2,int y2,string firstColor, string offsetColor, int a=0,int b=0,double sim=0.8)
        {
            int intX, intY;
            _dm.FindMultiColor(x1, y1, x2, y2, firstColor, offsetColor, sim, 0, out intX, out intY);
                if(intX>0&&intY>0)
                {
                    _dm.MoveToClick(intX + a, intY + b);
                    _dm.Delay(50);
                    return true;
                }
            return false;
        }
    }
}
