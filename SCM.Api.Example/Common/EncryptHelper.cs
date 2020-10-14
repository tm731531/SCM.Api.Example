using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Common
{
    public class EncryptHelper
    {
        /// <summary>
        /// 出貨管理查詢加解密(ShipManage/Search)
        /// </summary>
        public static void doTest()
        {

            var tarrgetStr = "要加密的字串";
            var 廠商統編 = "31244190";
            var 我們提供的ApiSecureKey = "ee13d27bfdc04bfbb1b6faa4ef046444";
            //加解密範例(測試區)
            var encode_string = encode($"{廠商統編}", tarrgetStr);
            var decode_string = decode($"{廠商統編}", encode_string);

            //加解密範例(正式區)
            var encode_string_normal = encode("廠商統編+我們提供的ApiSecureKey", tarrgetStr);
            var decode_string_normal = decode("廠商統編+我們提供的ApiSecureKey", encode_string);

            //範例1:正式區上線
            //      假如你的統編為 31244190
            //	我們提供的ApiSecureKey 為ee13d27bfdc04bfbb1b6faa4ef046444
            var encode_string_normal_withkey = encode($"{廠商統編}{我們提供的ApiSecureKey}", tarrgetStr);
            var decode_string_normal_withkey = decode($"{廠商統編}{我們提供的ApiSecureKey}", encode_string);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="unicode">公司統編</param>
        /// <param name="str">要加密的字串</param>
        public static string encode(string company_id, string str)
        {
            string encryptKey = company_id;

            var aes = new AesCryptoServiceProvider();
            var key = Encoding.UTF8.GetBytes(encryptKey);
            if (!aes.ValidKeySize(key.Length * 8))
            {
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                key = sha256.ComputeHash(Encoding.UTF8.GetBytes(encryptKey));
            }

            var md5Service = new MD5CryptoServiceProvider();
            var iv = md5Service.ComputeHash(Encoding.UTF8.GetBytes(encryptKey));

            return Convert.ToBase64String(AesEncrypt(Encoding.UTF8.GetBytes(str), key, iv, CipherMode.CBC));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="company_id">公司統編</param>
        /// <param name="encode_string">要解密的字串</param>
        /// <returns></returns>
        public static string decode(string company_id, string encode_string)
        {
            string encryptKey = company_id;

            var aes = new AesCryptoServiceProvider();
            var key = Encoding.UTF8.GetBytes(encryptKey);
            if (!aes.ValidKeySize(key.Length * 8))
            {
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                key = sha256.ComputeHash(Encoding.UTF8.GetBytes(encryptKey));
            }

            var md5Service = new MD5CryptoServiceProvider();
            var iv = md5Service.ComputeHash(Encoding.UTF8.GetBytes(encryptKey));

            return Encoding.UTF8.GetString(AesDecrypt(Convert.FromBase64String(encode_string), key, iv, CipherMode.CBC));
        }

        private static byte[] AesDecrypt(byte[] sourceBytes, byte[] keyBytes, byte[] ivBytes, CipherMode mode)
        {
            var aesService = new AesCryptoServiceProvider { Key = keyBytes, IV = ivBytes, Mode = mode };
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aesService.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(sourceBytes, 0, sourceBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        private static byte[] AesEncrypt(byte[] sourceBytes, byte[] keyBytes, byte[] ivBytes, CipherMode mode)
        {
            var aesService = new AesCryptoServiceProvider { Key = keyBytes, IV = ivBytes, Mode = mode };
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aesService.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(sourceBytes, 0, sourceBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
