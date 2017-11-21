using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography;


namespace Merrto.baseclass
{
    public class utils
    {
        //#region  加密
        //public string MD5(string strPwd)
        //{
            
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
        //    byte[] md5data = md5.ComputeHash(data);
        //    md5.Clear();
        //    string str = "";
        //    for (int i = 0; i < md5data.Length - 1; i++)
        //    {
        //        str += md5data[i].ToString("x").PadLeft(2, '0');
        //    }
        //    return str;

        //}
        //#endregion

        /// <summary> 
        /// MD5 加密函数 
        /// </summary> 
        /// <param name="str"></param> 
        /// <param name="code"></param> 
        /// <returns></returns> 
        //public static string MD5(string str)
        //{
        //    //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        //}

        public string StringToMD5Hash(string inputString)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encryptedBytes.Length; i++)
            {

                sb.AppendFormat("{0:x2}", encryptedBytes[i]);

            }

            return sb.ToString();
        }

        //        #region  加密
        //public string MD51(string strPwd)
        //{
        //    string str = "";
        //    byte[] result = Encoding.Default.GetBytes(strPwd);    //tbPass为输入密码的文本框
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] output = md5.ComputeHash(result);
        //    str = BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        //    return str;

        //}
        //#endregion



        #region 生成指定位数随机数
        private static char[] constant =   
          {   
            '0','1','2','3','4','5','6','7','8','9',   
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };

        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

       

        public static string GetNumRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            char[] NumStr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }
        #endregion

        //过滤字符
        public static bool CheckStrType(string str, string type)
        {
            bool b = false;
            if (type.IndexOf("|") == -1)
            {
                if (str == type) b = true;
            }
            else
            {
                string[] Ttype = type.Split('|');
                foreach (string s in Ttype)
                {
                    if (s == str)
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }

        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
        ///// <summary>
        ///// 获取Request值并过滤'
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public static string VRequest(string name)
        //{
        //    return HttpContext.Current.Request[name] == null ? "" : CheckStr(HttpContext.Current.Request[name]);
        //}

        ///// <summary>
        ///// 获取Request值并过滤'
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="type">0为QUERY，1为FORM</param>
        ///// <returns></returns>
        //public static string VRequest(string name, string type)
        //{
        //    if (type == "1")
        //        return HttpContext.Current.Request.Form[name] == null ? "" : CheckStr(HttpContext.Current.Request.Form[name]);
        //    else
        //        return HttpContext.Current.Request.QueryString[name] == null ? "" : CheckStr(HttpContext.Current.Request.QueryString[name]);
        //}

        ///// <summary>
        ///// 获取Request值并过滤'
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="type">0为QUERY，1为FORM</param>
        ///// <param name="def">如果为NULL的默认值</param>
        ///// <returns></returns>
        //public static string VRequest(string name, string type, string def)
        //{
        //    if (type == "1")
        //        return HttpContext.Current.Request.Form[name] == null ? def : CheckStr(HttpContext.Current.Request.Form[name]);
        //    else
        //        return HttpContext.Current.Request.QueryString[name] == null ? def : CheckStr(HttpContext.Current.Request.QueryString[name]);
        //}

        ///// <summary> 
        ///// MD5 加密函数 
        ///// </summary> 
        ///// <param name="str"></param> 
        ///// <param name="code"></param> 
        ///// <returns></returns> 
        //public static string MD5(string str)
        //{
        //    return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        //}
    }
}
