using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    class SimpleCipher
    {
        private static int CRYPTKEY = 90;
        public static byte[] cancelHead(byte[] paramArrayOfByte)
        {
            if ((paramArrayOfByte == null) || (paramArrayOfByte.Length < 8))
            {
                return null;
            }
            //00-00-00-52-70-6C-61-79-65-72-40-6C-74-65-73-74-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-01-76-78-9C-AB-56-4A-4C-2E-C9
            int index = BitConverter.ToString(paramArrayOfByte).IndexOf("78-9C"); 
            
            if(index>=120&&index<160)
            {
                if(index==120)
                {
                    return paramArrayOfByte;
                }
                if(index>120)
                {
                    int i = paramArrayOfByte.ToList().IndexOf(0x78);
                    //复制头字节并输出
                    byte[] headBytes = new byte[i-4-32-4];
                    Array.Copy(paramArrayOfByte, 0, headBytes, 0, i - 4 - 32 - 4);
                    Debug.WriteLine(BitConverter.ToString(headBytes));
                    //长度4+命令32+编号4+压缩数据
                    byte[] arrayOfByte = new byte[paramArrayOfByte.Length - headBytes.Length];
                    Array.Copy(paramArrayOfByte, headBytes.Length, arrayOfByte, 0, paramArrayOfByte.Length - headBytes.Length);
                    Debug.WriteLine(BitConverter.ToString(arrayOfByte));
                    return arrayOfByte;
                }
            }
            return null;
        }

        public static byte[] decompressAfterdecrypt(byte[] paramArrayOfByte)
        {
            if ((paramArrayOfByte == null) || (paramArrayOfByte.Length == 0))
            {
                return null;
            }
            return Zip.DeCompress(decrypt(paramArrayOfByte));
        }

        public static byte[] decrypt(byte[] paramArrayOfByte)
        {
            int j = paramArrayOfByte.Length;
            byte[] arrayOfByte = new byte[j];
            int i = 0;
            for (;;)
            {
                if (i >= j)
                {
                    return arrayOfByte;
                }
                arrayOfByte[i] = ((byte)(paramArrayOfByte[i] ^ CRYPTKEY));
                i += 1;
            }
        }

        public static byte[] ecrypt(byte[] paramArrayOfByte)
        {
            int j = paramArrayOfByte.Length;
            byte[] arrayOfByte = new byte[j];
            int i = 0;
            for (;;)
            {
                if (i >= j)
                {
                    return arrayOfByte;
                }
                arrayOfByte[i] = ((byte)(paramArrayOfByte[i] ^ CRYPTKEY));
                i += 1;
            }
        }

        //public static byte[] ecryptAfterCompressData(byte[] paramArrayOfByte)
        //{
        //    return ecrypt(Zip.compressData(paramArrayOfByte));
        //}
    }
}
