using EMS.BL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM = EMS.Model.User;

namespace EMS.BL
{
    public interface IUserBL : IMessageModel, IDisposable
    {
        IQueryable<VM.VmTblUser> GetUserList();

        List<VM.VmTblUser> GetUserList(VM.UserSearchModel search);

        VM.VmTblUser GetUserByID(int id);

        VM.VmTblUser GetUserByLogonName(string logonName);

        bool CreateUser(VM.VmTblUser model);

        bool UpdateUser(VM.VmTblUser model);

        //bool DeleteUser(VM.VmTblUser model);
        bool DeleteUser(int id);

        bool IsExistUser(VM.VmTblUser model);
    }
}