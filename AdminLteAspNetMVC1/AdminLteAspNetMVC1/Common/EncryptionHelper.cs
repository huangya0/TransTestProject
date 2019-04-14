using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdminLteAspNetMVC1.Common
{
    public class EncryptionHelper
    {
        public static readonly string EncryptKey = "sd54nfg1";

        public static string Encrypt(string originString)
        {
            return Encrypt(originString, EncryptKey);
        }

        public static string Decrypt(string cryptString)
        {
            return Decrypt(cryptString, EncryptKey);
        }

        #region Encrypt Function
        /// <summary>
        /// Encrypt Function
        /// </summary>
        /// <param name="pToEncrypt">need encrypt string</param>
        /// <param name="sKey">encrypt key</param>
        /// <returns>encrypted string</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();

        }
        #endregion

        #region Decrypt Function
        /// <summary>
        ///  Decrypt Function
        /// </summary>
        /// <param name="pToDecrypt">need decrypt string</param>
        /// <param name="sKey">encrypt key</param>
        /// <returns>decrypted string</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }


            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());

        }
        #endregion
    }
}