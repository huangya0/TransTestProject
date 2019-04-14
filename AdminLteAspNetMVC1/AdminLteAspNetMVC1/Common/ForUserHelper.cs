using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLteAspNetMVC1.Common
{
    public class ForUserHelper : IForUserHelper
    {
        public bool IsSiteAdmin()
        {
            //return UserHelper.IsSiteAdmin(UserHelper.GetCurrentUserID());
            return true;
        }
        /// <summary>
        /// Get Current User Info from Session State.
        /// If not exist on Session State, then it will use User Name to DB get one.
        /// </summary>
        /// <returns></returns>
        public UserItem GetCurrentUser()
        {
            return UserHelper.GetCurrentUser();
        }

        public int GetCurrentUserID()
        {
            return UserHelper.GetCurrentUser().ID;
        }

        public void ResetCurrentUser()
        {
            UserHelper.ResetCurrentUser();
        }


        //public void SetCookie(string key, string value)
        //{
        //    UserHelper.SetCookie(key, value);
        //}

        public int GetCurrentUserRoleId(string userName)
        {
            return UserHelper.GetCurrentUserRoleId(userName);
        }

        public Dictionary<int, string> GetCurrentRole()
        {
            return UserHelper.GetCurrentRole();
        }

        //public bool IsOrgUnitAdmin(int companyId)
        //{
        //    return UserHelper.IsOrgUnitAdmin(companyId);
        //}

        //public VM.UserIdentityType GetUserIdentityType(int companyId)
        //{
        //    return UserHelper.GetUserIdentityType(companyId);
        //}
    }
}
