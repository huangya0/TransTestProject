using EMS.Model;
using EMS.Model.Common;
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
        private const string USER_KEY = "UserSessionKey";

        public static UserItem GetCurrentUser()
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
                    UserItem user = JsonConvert.DeserializeObject<UserItem>(additionalData);
                    return user;
                }
            }

            return null;
        }

        public static void ResetCurrentUser()
        {
            if (HttpContext.Current.Request == null)
                return;

            //HttpContext.Current.Session[USER_KEY] = null;
            CommonHelper.RemoveCookie(USER_KEY);
            CommonHelper.RemoveCookie("dbLang");
            //remove cookie for UserIdentityType and User,Company's Message
            //CommonHelper.RemoveCookie("UserIdentityType");
            //CommonHelper.RemoveCookie("UserMsgIdentityType");
            //CommonHelper.RemoveCookie("companyCode");
        }

        public static int GetCurrentUserRoleId(string userName)
        {
            using (var roleDB = new EMS.BL.Account.Role())
            {
                return roleDB.GetRoleId(userName);
            }
        }

        public static Dictionary<int, string> GetCurrentRole()
        {
            using (var roleDB = new EMS.BL.Account.Role())
            {
                return roleDB.GetUserRoleMsg(GetCurrentUserID());
            }
        }

        public static int GetCurrentUserID()
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.ID;
            }
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

        public static void WriteLoginCookie(UserItem user)
        {
            string additionalData = JsonConvert.SerializeObject(user);
            WriteLoginCookie(user.LogonName, additionalData);
        }
    }
}