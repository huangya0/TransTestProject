//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using EMS.Model.Role;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EMS.BL.Common
{
    public interface IBaseControllerBLL
    {
        string GetCompanyDateFormat(int companyId);
        int GetLongonUserRole(int id);
        List<RoleItemModel> GetLongonUserRoles(int userId);
    }
}