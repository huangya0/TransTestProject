using EMS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AdminLteAspNetMVC1.Common
{
    public class UserHelper
    {
        public static UserModel GetCurrentUser()
        {
            if (HttpContext.Current == null ||
                HttpContext.Current.Session == null)
                return null;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsIdentity formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                string additionalData = formsIdentity.Ticket.UserData;
                if (string.IsNullOrEmpty(additionalData))
                {
                    return null;
                }
                else
                {
                    UserModel user = JsonConvert.DeserializeObject<UserModel>(additionalData);
                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Write cookie for login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="companySplit"></param>
        public static void WriteLoginCookie(string userName, string additionalData)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                                                1,
                                                                userName,
                                                                DateTime.Now,
                                                                DateTime.Now.Add(FormsAuthentication.Timeout),
                                                                true,
                                                                additionalData
                                                                );
            HttpCookie cookie = new HttpCookie(
              FormsAuthentication.FormsCookieName,
              FormsAuthentication.Encrypt(ticket));
            cookie.Expires.AddMinutes(20);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void WriteLoginCookie(UserModel user)
        {
            string additionalData = JsonConvert.SerializeObject(user);
            WriteLoginCookie(user.LogonName, additionalData);
        }
    }
}