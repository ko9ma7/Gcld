using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    /// <summary>
    /// 按照先后顺序合并字节数组类
    /// </summary>
    public class CombineBytes
    {
        /// <summary>
        /// 按照先后顺序合并字节数组，并返回合并后的字节数组。
        /// </summary>
        /// <param name="firstBytes">第一个字节数组</param>
        /// <param name="firstIndex">第一个字节数组的开始截取索引</param>
        /// <param name="firstLength">第一个字节数组的截取长度</param>
        /// <param name="secondBytes">第二个字节数组</param>
        /// <param name="secondIndex">第二个字节数组的开始截取索引</param>
        /// <param name="secondLength">第二个字节数组的截取长度</param>
        /// <returns></returns>
        public static byte[] ToArray(byte[] firstBytes, int firstIndex, int firstLength, byte[] secondBytes, int secondIndex, int secondLength)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(firstBytes, firstIndex, firstLength);
                bw.Write(secondBytes, secondIndex, secondLength);

                bw.Close();
                bw.Dispose();

                return ms.ToArray();
            }
        }
    }
}
