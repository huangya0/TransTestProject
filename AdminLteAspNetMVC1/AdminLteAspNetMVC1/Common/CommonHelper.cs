using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AdminLteAspNetMVC1.Common
{
    public static class CommonHelper
    {

        public static string ValidationCode_KEY = EMS.Utility.Web.ConfigurationHelper.GetAppSetting("ValidationCode_KEY");
        public static string GenerateCheckCode()
        {
            int number = 0;
            char code = '\0';
            string checkCode = String.Empty;
            char[] availableCode =
                    {
                        '2','3','4','6','7','9','A','C','D','E','G','H','J',
                        'K','M','N','P','Q','R','T','U','V','W','X','Y','Z'
                    };

            System.Random random = new Random();

            for (int i = 0; i <= 5; i++)
            {
                number = random.Next();

                int indexChar = number % availableCode.Length;
                code = availableCode[indexChar];

                checkCode += code.ToString();
            }
            return checkCode;
        }
        public static byte[] CreateCheckCodeImage(string checkCode)
        {
            if (string.IsNullOrWhiteSpace(checkCode))
            {
                throw new ArgumentException("Check code is null!");
            }

            //if (checkCode == null || checkCode.Trim() == String.Empty)
            //{
            //    throw new ArgumentException("Check code is null!");
            //}

            System.Drawing.Bitmap image = new System.Drawing.Bitmap(Convert.ToInt32(Math.Ceiling((double)(checkCode.Length * 25))), 40);
            Graphics g = Graphics.FromImage(image);

            try
            {
                Random random = new Random();

                g.Clear(Color.White);

                for (int i = 0; i <= 12; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    int colorImage = random.Next(2);
                    Color penColor = default(Color);
                    if (colorImage == 1)
                    {
                        penColor = Color.DarkOliveGreen;
                    }
                    else
                    {
                        penColor = Color.FromArgb(171, 192, 13);
                    }

                    g.DrawLine(new Pen(penColor), x1, y1, x2, y2);
                }

                Font font = new System.Drawing.Font("Arial", 18, (System.Drawing.FontStyle.Strikeout));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(0, 0, image.Width, image.Height), Color.FromArgb(0, 112, 192), Color.FromArgb(0, 188, 242), 1.2f, true);
                g.DrawString(checkCode, font, brush, 17, 8);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                //context.Response.ClearContent();
                //context.Response.ContentType = "image/Gif";
                //context.Response.BinaryWrite(ms.ToArray());
                return ms.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public static void SetCookie(string key, Dictionary<string, string> values, DateTime exper)
        {
            HttpCookie ck;
            if (System.Web.HttpContext.Current.Request.Cookies[key] != null)
            {
                ck = System.Web.HttpContext.Current.Response.Cookies[key];
                foreach (var value in values)
                {
                    ck.Values.Add(value.Key, value.Value);
                }
            }
            else
            {
                ck = new HttpCookie(key);
                foreach (var value in values)
                {
                    ck.Values.Add(value.Key, value.Value);
                }
            }
            if (exper != null)
            {
                ck.Expires = exper;
            }
            System.Web.HttpContext.Current.Response.Cookies.Add(ck);
        }

        public static void SetCookie(System.Web.HttpCookie ck)
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(ck);
        }

        public static void SetCookie(string key, string value, DateTime? exper = null, bool httpOnly = true)
        {
            //request
            HttpCookie ck;
            value = HttpUtility.UrlEncode(value, System.Text.UTF8Encoding.UTF8);
            if (System.Web.HttpContext.Current.Request.Cookies[key] != null)
            {
                ck = System.Web.HttpContext.Current.Request.Cookies[key];
                ck.Value = value;
            }
            else
            {
                ck = new HttpCookie(key);
                ck.Value = value;
            }
            if (exper != null)
            {
                ck.Expires = exper.Value;
                ck.HttpOnly = httpOnly;
            }

            //response
            HttpCookie ckRes;
            if (System.Web.HttpContext.Current.Response.Cookies[key] != null)
            {
                ckRes = System.Web.HttpContext.Current.Response.Cookies[key];
                ckRes.Value = value;
            }
            else
            {
                ckRes = new HttpCookie(key);
                ckRes.Value = value;
            }
            if (exper != null)
            {
                ckRes.Expires = exper.Value;
                ckRes.HttpOnly = httpOnly;
            }
        }

        public static void RemoveCookie(string key)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpCookie ck = System.Web.HttpContext.Current.Response.Cookies[key];
                ck.Value = null;
                ck.Expires = DateTime.Now.AddMinutes(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(ck);
            }
        }

        public static void RemoveCookie(string cookieName, string valueKey)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpCookie ck = System.Web.HttpContext.Current.Response.Cookies[cookieName];
                ck.Values.Remove(valueKey);
                System.Web.HttpContext.Current.Response.Cookies.Add(ck);
            }
        }

        public static string StringToCharCode(char c)
        {
            return ((int)c).ToString();
        }

        public static string StringToCharCode(string str)
        {
            char[] chars = str.ToCharArray();
            string result = "";
            for (int i = 0; i < chars.Length; i++)
            {
                result += StringToCharCode(chars[i]) + ",";
            }
            return result.Trim(',');
        }

        public static object ReadCookie(string cookieName)
        {
            return System.Web.HttpContext.Current.Request.Cookies[cookieName];
        }


        // Serialize object to json string
        public static string ToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Serialize(obj);
            string json = JsonConvert.SerializeObject(obj, Formatting.None);
            return json;
        }


        //Return object from Cookie after serializing json string
        public static T ReadObjectInCookie<T>(string key)
        {
            var objCookie = System.Web.HttpContext.Current.Request.Cookies[key];
            if (objCookie == null || string.IsNullOrEmpty(objCookie.Value))
                return default(T);

            //JavaScriptSerializer jss = new JavaScriptSerializer();

            //byte[] encodeByte = System.Text.Encoding.Default.GetBytes (objCookie.Value);
            //UTF8Encoding utf8 = new UTF8Encoding();
            //string culture = Thread.CurrentThread.CurrentCulture.Name;
            //string deCodeStr = utf8.GetString(encodeByte);

            string val = HttpUtility.UrlDecode(objCookie.Value, System.Text.UTF8Encoding.UTF8);

            return JsonConvert.DeserializeObject<T>(val);

            //return jss.Deserialize<T>(objCookie.Value);
        }

        //Save object in Cookie
        public static void SaveObjectInCookie(string key, object obj, DateTime? expr = null)
        {
            string cookieVal = ToJson(obj);

            cookieVal = HttpUtility.UrlEncode(cookieVal, System.Text.UTF8Encoding.UTF8); //HttpContext.Current.Server.UrlEncode(cookieVal);

            //UTF8Encoding utf8 = new UTF8Encoding();
            //byte[] encodeByte = utf8.GetBytes(cookieVal);
            //string test = utf8.GetString(encodeByte);

            //string encodeCookieVal = System.Text.Encoding.ASCII.GetString(encodeByte);

            if (string.IsNullOrEmpty(cookieVal))
            {
                return;
            }
            DateTime newExpr;
            if (expr.HasValue)
            {
                newExpr = expr.Value;
            }
            else
            {
                newExpr = DateTime.Now.AddMinutes(20);
            }
            //SetCookie(key, cookieVal, expr);

            HttpCookie ck;

            if (System.Web.HttpContext.Current.Request.Cookies[key] != null)
            {
                ck = System.Web.HttpContext.Current.Request.Cookies[key];
            }
            else
            {
                ck = new HttpCookie(key);
            }
            ck.Value = cookieVal;
            ck.Expires = newExpr;
            System.Web.HttpContext.Current.Request.Cookies.Set(ck);
            System.Web.HttpContext.Current.Response.Cookies.Add(ck);
        }

        //Save Encryt object in Cookie 
        public static void SaveEncryObjectInCookie(string key, object obj, DateTime? expr = null)
        {
            string cookieVal = ToJson(obj);

            cookieVal = EncryptionHelper.Encrypt(cookieVal);

            cookieVal = HttpUtility.UrlEncode(cookieVal, System.Text.UTF8Encoding.UTF8); //HttpContext.Current.Server.UrlEncode(cookieVal);

            if (string.IsNullOrEmpty(cookieVal))
            {
                return;
            }
            DateTime newExpr;
            if (expr.HasValue)
            {
                newExpr = expr.Value;
            }
            else
            {
                newExpr = DateTime.Now.AddMinutes(20);
            }
            //SetCookie(key, cookieVal, expr);

            HttpCookie ck;

            ck = new HttpCookie(key);
            ck.Value = cookieVal;
            ck.Expires = newExpr;
            System.Web.HttpContext.Current.Response.Cookies.Add(ck);
        }

        //Return Decrypt object from Cookie after serializing json string
        public static T ReadDecryptObjectInCookie<T>(string key)
        {
            var objCookie = System.Web.HttpContext.Current.Request.Cookies[key];
            if (objCookie == null || string.IsNullOrEmpty(objCookie.Value))
                return default(T);

            string val = HttpUtility.UrlDecode(objCookie.Value, System.Text.UTF8Encoding.UTF8);

            var decryptValue = EncryptionHelper.Decrypt(val);

            return JsonConvert.DeserializeObject<T>(decryptValue);

            //return jss.Deserialize<T>(objCookie.Value);
        }

        //clear cookie value in Request
        public static void ClearRequestCookieValue(string key)
        {
            var requertCk = System.Web.HttpContext.Current.Request.Cookies[key];

            if (null != requertCk)
            {
                requertCk.Value = null;
                requertCk.Expires = DateTime.Now.AddMinutes(-1);
                System.Web.HttpContext.Current.Request.Cookies.Add(requertCk);
            }
            if (null != System.Web.HttpContext.Current.Response.Cookies[key])
            {
                System.Web.HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddMinutes(-1);
            }
        }

        //Add '/' in the end of url
        public static string AddEndSlashOfUrl(string strUri)
        {
            int iLength = strUri.Length;
            for (int i = iLength - 1; i >= 0; i--)
            {
                if (strUri[i] == '/')
                {
                    strUri = strUri.Substring(0, --iLength);
                }
                else
                {
                    break;
                }
            }
            return strUri + "/";
        }
        public static string GetHostName()
        {
            // undone: aaron 2014-7-10, should not use ConfigurationManager in Model Layer
            var appurl = EMS.Utility.Web.ConfigurationHelper.GetAppSetting("AppUrl");//ConfigurationManager.AppSettings["AppUrl"];
            if (string.IsNullOrEmpty(appurl))
            {
                return "";
            }
            else
            {
                return appurl;
            }
        }

        public static string GetDomainHostName()
        {
            // undone: aaron 2014-7-10, should not use ConfigurationManager in Model Layer
            var appurl = EMS.Utility.Web.ConfigurationHelper.GetAppSetting("DomainAppUrl");//ConfigurationManager.AppSettings["AppUrl"];
            if (string.IsNullOrEmpty(appurl))
            {
                return "";
            }
            else
            {
                return appurl;
            }
        }
    }
}