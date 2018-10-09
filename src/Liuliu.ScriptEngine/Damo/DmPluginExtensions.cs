using System.Diagnostics;

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
        /// <returns></returns>
        public static bool IsExistPic(this DmPlugin _dm,int x1,int y1,int x2,int y2,string picname)
        {
            int intX, intY;
            _dm.FindPic(x1, y1, x2, y2, picname, "101010", 0.9, 0, out intX, out intY);
            if(intX>0&&intY>0)
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
        /// <returns></returns>
        public static bool FindPicAndClick(this DmPlugin _dm, int x1, int y1, int x2, int y2, string picname,int a=0,int b=0)
        {
            int intX, intY;
            _dm.FindPic(x1, y1, x2, y2, picname, "101010", 0.9, 0, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                //Debug.WriteLine("找图[" + picname + "]成功!");
                _dm.MoveToClick(intX+a, intY+b);
                _dm.Delay(50);
                return true;
            }
            Debug.WriteLine("找图[" + picname + "]失败!");
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
            _dm.FindStr(x1, y1, x2, y2, str, color, 0.9, out intX, out intY);
            if (intX > 0 && intY > 0)
            {
                //Debug.WriteLine("找字[" + str + "]成功!");
                _dm.MoveToClick(intX + a, intY + b);
                _dm.Delay(50);
                return true;
            }
            Debug.WriteLine("找字[" + str + "]失败!");
            return false;
        }

    }
}
