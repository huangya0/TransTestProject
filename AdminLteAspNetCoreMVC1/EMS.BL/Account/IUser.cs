using EMS.BL.Common;
using EMS.Model.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BL.Account
{
    public interface IUser : IMessageModel
    {
        int GetLongonUserRole(int userId);
        System.Collections.Generic.List<RoleItemModel> GetLongonUserRoles(int userId);
        System.Collections.Generic.List<RoleItemModel> GetUserRoles(int userId);
    }
}
