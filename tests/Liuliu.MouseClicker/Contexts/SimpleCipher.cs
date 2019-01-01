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
            //if ((102 == paramArrayOfByte[0]) && 
            //    (108 == paramArrayOfByte[1]) &&
            //    (121 == paramArrayOfByte[2]) && 
            //    (115 == paramArrayOfByte[3]) && 
            //    (116 == paramArrayOfByte[4]) && 
            //    (109 == paramArrayOfByte[5]) && 
            //    (33 == paramArrayOfByte[6]))
            if(0x0D==paramArrayOfByte[2]&&0x0A==paramArrayOfByte[3]&& 0x00 == paramArrayOfByte[4] && 0x00 == paramArrayOfByte[5] && 0x00 == paramArrayOfByte[6])
            {try
             {
                    byte[] headBytes = new byte[8];
                    Array.Copy(paramArrayOfByte, 0, headBytes, 0, 8);
                    Debug.WriteLine(BitConverter.ToString(headBytes));
                    byte[] arrayOfByte = new byte[paramArrayOfByte.Length - 8];
                    Array.Copy(paramArrayOfByte, 8, arrayOfByte, 0, paramArrayOfByte.Length - 8);
                    // Debug.WriteLine(BitConverter.ToString(arrayOfByte));
                    return arrayOfByte;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message+"888888888888888888888888");
                }
              
            }
            if(0x0D == paramArrayOfByte[3] && 0x0A == paramArrayOfByte[4] && 0x00 == paramArrayOfByte[5] && 0x00 == paramArrayOfByte[6] && 0x00 == paramArrayOfByte[7])
            {
                try
                {
                    byte[] headBytes = new byte[9];
                    Array.Copy(paramArrayOfByte, 0, headBytes, 0, 9);
                    Debug.WriteLine(BitConverter.ToString(headBytes));
                    byte[] arrayOfByte = new byte[paramArrayOfByte.Length - 9];
                    Array.Copy(paramArrayOfByte, 9, arrayOfByte, 0, paramArrayOfByte.Length - 9);
                    // Debug.WriteLine(BitConverter.ToString(arrayOfByte));
                    return arrayOfByte;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message + "9999999999999999999999");
                }
            }
            return paramArrayOfByte;
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
