using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.PlatformLogin._07073sy
{
    public class Des
    {


        public static string ALGORITHM_DES = "DES/CBC/PKCS5Padding";
        public static string key = Constant.key;

        public static byte[] decode(byte[] paramArrayOfByte)
        {
            try
            {
                //    OSharp.Utility.Secutiry.DesHelper.Decrypt();
                ////new SecureRandom();
                //Object localObject = new DESKeySpec(key.getBytes());
                //localObject = SecretKeyFactory.getInstance("DES").generateSecret((KeySpec)localObject);
                //Cipher localCipher = Cipher.getInstance("DES/CBC/PKCS5Padding");
                //localCipher.init(2, (Key)localObject, new IvParameterSpec(key.getBytes()));
                //paramArrayOfByte = localCipher.doFinal(paramArrayOfByte);
                //return paramArrayOfByte;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
            return paramArrayOfByte;
        }

        public static string decodeValue(string paramString)
        {
            try
            {
                //if ((System.getProperty("os.name") != null) && ((System.getProperty("os.name").equalsIgnoreCase("sunos")) || (System.getProperty("os.name").equalsIgnoreCase("linux")))) { }
                //for (paramString = decode(Base64.decode(paramString)); ; paramString = decode(Base64.decode(paramString)))
                //{
                //    return new String(paramString);
                //}
                //return "";
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message + ex.StackTrace); }
            return "";
        }

        public static string encode(string paramString)

        {
            return null;//encode(paramString.getBytes());
        }

        public static string encode(byte[] paramArrayOfByte)
        {
            try
            {
                //Object localObject = new DESKeySpec(key.getBytes());
                //localObject = SecretKeyFactory.getInstance("DES").generateSecret((KeySpec)localObject);
                //Cipher localCipher = Cipher.getInstance("DES/CBC/PKCS5Padding");
                //localCipher.init(1, (Key)localObject, new IvParameterSpec(key.getBytes()));
                //paramArrayOfByte = Base64.encode(localCipher.doFinal(paramArrayOfByte));
                return paramArrayOfByte.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
            return "";
        }

    }
}
