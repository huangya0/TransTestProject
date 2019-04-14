using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLteAspNetMVC1.Common
{
    public interface IForUserHelper
    {
        UserItem GetCurrentUser();
        int GetCurrentUserID();
        void ResetCurrentUser();
        int GetCurrentUserRoleId(string userName);
        //void SetCookie(string key, string value);
        Dictionary<int, string> GetCurrentRole();
        //bool IsOrgUnitAdmin(int companyId);
        //VM.UserIdentityType GetUserIdentityType(int companyId);
        bool IsSiteAdmin();
    }
}
