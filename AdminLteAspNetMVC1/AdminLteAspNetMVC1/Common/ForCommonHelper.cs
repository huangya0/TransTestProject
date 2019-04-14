using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteAspNetMVC1.Common
{
    public class ForCommonHelper : IForCommonHelper
    {
        public string GenerateCheckCode()
        {
            return CommonHelper.GenerateCheckCode();
        }

        public byte[] CreateCheckCodeImage(string checkCode)
        {
            return CommonHelper.CreateCheckCodeImage(checkCode);
        }

        public void SetCookie(string key, Dictionary<string, string> values, DateTime exper)
        {
            CommonHelper.SetCookie(key, values, exper);
        }

        public void SetCookie(System.Web.HttpCookie ck)
        {
            CommonHelper.SetCookie(ck);
        }

        public void SetCookie(string key, string value, DateTime? exper = null)
        {
            CommonHelper.SetCookie(key, value, exper);
        }

        public void RemoveCookie(string key)
        {
            CommonHelper.RemoveCookie(key);
        }

        public void RemoveCookie(string cookieName, string valueKey)
        {
            CommonHelper.RemoveCookie(cookieName, valueKey);
        }

        public string StringToCharCode(char c)
        {
            return CommonHelper.StringToCharCode(c);
        }

        public string StringToCharCode(string str)
        {
            return CommonHelper.StringToCharCode(str);
        }

        public object ReadCookie(string cookieName)
        {
            return CommonHelper.ReadCookie(cookieName);
        }

        public string ToJson(object obj)
        {
            return CommonHelper.ToJson(obj);
        }

        public T ReadObjectInCookie<T>(string key)
        {
            return CommonHelper.ReadObjectInCookie<T>(key);
        }

        public void SaveObjectInCookie(string key, object obj, DateTime? expr = null)
        {
            CommonHelper.SaveObjectInCookie(key, obj, expr);
        }

        public void ClearRequestCookieValue(string key)
        {
            CommonHelper.ClearRequestCookieValue(key);
        }

        public void SaveEncryObjectInCookie(string key, object obj, DateTime? expr = null)
        {
            CommonHelper.SaveEncryObjectInCookie(key, obj, expr);
        }

        public T ReadDecryptObjectInCookie<T>(string key)
        {
            return CommonHelper.ReadDecryptObjectInCookie<T>(key);
        }
    }
}