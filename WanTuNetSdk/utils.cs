using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WanTuNetSdk.common
{
    public static class utils
    {
        public static string GetToken()
        {
            return @"UPLOAD_AK_TOP MjMyNzc2NDU6ZXlKcGJuTmxjblJQYm14NUlqb2lNQ0lzSW01aGJXVnpjR0ZqWlNJNklubHBhR1VpTENKbGVIQnBjbUYwYVc5dUlqb2lMVEVpZlE6NjFlN2Y1MjYwMDZlMjM2ZGE2OGJhYzg0ZmE2ZDQ1OWI4NmUwNmQ2ZQ";
        }
        /// <summary>
        /// 默认的上传策略，1小时过期时间，使用uuid作为文件名
        /// </summary>
        /// <param name="accesskey">百川密钥AK</param>
        /// <param name="secretkey">百川密钥SK</param>
        /// <param name="myspace">空间名字</param>
        /// <returns></returns>
        public static string GetPicTokenDefault(string accesskey, string secretkey, string myspace)
        {
            DateTime d1 = DateTime.Now.AddHours(1);
            DateTime d2 = new DateTime(1970, 1, 1); 
            double d=  d1.Subtract(d2).TotalMilliseconds;
            long expiration = Convert.ToInt64(d);
            var Policy = new PhotoPolicy()
            {
                expiration = expiration.ToString(),
                insertOnly = 0,
                name = "${uuid}",
                NameSpace = myspace
            };
            string uploadPolicy = JsonConvert.SerializeObject(Policy, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return GetPicTokenByPolicy(accesskey, secretkey, uploadPolicy);
          
        }
        /// <summary>
        /// 自己组织的上传策略
        /// </summary>
        /// <param name="accesskey">百川密钥AK</param>
        /// <param name="secretkey">百川密钥SK</param>
        /// <param name="uploadPolicy">上传策略的json</param>
        /// <returns></returns>
        public static string GetPicTokenByPolicy(string accesskey, string secretkey, string uploadPolicy)
        {
            string encodedPolicy = GetBase64String(uploadPolicy);
            string sign = GetHMACSHA1Str(encodedPolicy, secretkey);
            string uploadToken = @"UPLOAD_AK_TOP " + GetBase64String(accesskey + ':' + encodedPolicy + ':' + sign);
            return uploadToken;
        }

        public static string BulidUploadPolicy(PhotoPolicy pPolicy)
        {
            string uploadPolicy= JsonConvert.SerializeObject(pPolicy, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return uploadPolicy;
        }

        private static string GetBase64String(string str)
        {
           byte[] bytes = Encoding.UTF8.GetBytes(str);
            return  Convert.ToBase64String(bytes).Replace("=","");
        }

        private static string GetHMACSHA1Str(string str, string secretkey)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes(secretkey);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(str);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            //return Convert.ToBase64String(hashBytes);
            return ByteToHexStr(hashBytes);


            //byte[] byteData = Encoding.UTF8.GetBytes(str);
            //HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretkey));
            //CryptoStream cs = new CryptoStream(Stream.Null, hmac, CryptoStreamMode.Write);
            //cs.Write(byteData, 0, byteData.Length);
            //cs.Close();
            //return Convert.ToBase64String(hmac.Hash);
        }
        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("x2") ;
                }
            }
            return returnStr.ToLower();
        } 
    }
}