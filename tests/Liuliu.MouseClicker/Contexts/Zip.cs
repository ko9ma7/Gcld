using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class Zip
    {
        //public static byte[] decompressData(byte[] paramArrayOfByte)
        //  {
        //    ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream();
        //    int i = -1;
        //    for (;;)
        //    {
        //      try
        //      {
        //        localInflater = new Inflater();
        //        localInflater.setInput(paramArrayOfByte, 0, paramArrayOfByte.length);
        //        paramArrayOfByte = new byte[1024];
        //        if (i != 0) {
        //          continue;
        //        }
        //        localInflater.end();
        //      }
        //      catch (Exception paramArrayOfByte)
        //      {
        //        Inflater localInflater;
        //        continue;
        //      }
        //      return localByteArrayOutputStream.toByteArray();
        //      i = localInflater.inflate(paramArrayOfByte);
        //      localByteArrayOutputStream.write(paramArrayOfByte, 0, i);
        //    }

        /// <summary>
        /// 解压缩算法
        /// </summary>
        /// <param name="pBytes"></param>
        /// <returns></returns>
        public static byte[] DeCompress(byte[] pBytes)
        {
            MemoryStream mMemory = new MemoryStream();
            using (InflaterInputStream mStream = new InflaterInputStream(new MemoryStream(pBytes)))
            {
                Int32 mSize;
                byte[] mWriteData = new byte[4096];
                while (true)
                {
                    mSize = mStream.Read(mWriteData, 0, mWriteData.Length);
                    if (mSize > 0)
                        mMemory.Write(mWriteData, 0, mSize);
                    else
                        break;
                }
            }
            return mMemory.ToArray();
        }
    }

}
