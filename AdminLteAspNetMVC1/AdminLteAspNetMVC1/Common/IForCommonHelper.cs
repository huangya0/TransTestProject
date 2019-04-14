using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteAspNetMVC1.Common
{
    public interface IForCommonHelper
    {
        void ClearRequestCookieValue(string key);
        byte[] CreateCheckCodeImage(string checkCode);
        string GenerateCheckCode();
        object ReadCookie(string cookieName);
        T ReadObjectInCookie<T>(string key);
        void RemoveCookie(string cookieName, string valueKey);
        void RemoveCookie(string key);
        void SaveObjectInCookie(string key, object obj, DateTime? expr = null);
        void SetCookie(string key, System.Collections.Generic.Dictionary<string, string> values, DateTime exper);
        void SetCookie(string key, string value, DateTime? exper = null);
        void SetCookie(System.Web.HttpCookie ck);
        string StringToCharCode(char c);
        string StringToCharCode(string str);
        string ToJson(object obj);
        T ReadDecryptObjectInCookie<T>(string key);
        void SaveEncryObjectInCookie(string key, object obj, DateTime? expr = null);
    }
}