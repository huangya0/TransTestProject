using EMS.BL.Common;
using EMS.DataProvider.Contexts;
using EMS.Model.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BL.Account
{
    public class User : BaseBusinessLogic, IDisposable, IUser
    {
        private readonly EmsWebDB context;

        public User()
        {
            context = new EmsWebDB();
        }
        public int GetLongonUserRole(int userId)
        {
            var userRole = context.Common_Authen_RoleUser.FirstOrDefault(i => i.UserID == userId);
            if (userRole.RoleID != 0 && userRole != null)
            {
                return userRole.RoleID;
            }
            return 0;
        }
        public List<RoleItemModel> GetLongonUserRoles(int userId)
        {
            var userRolequery = context.Common_Authen_RoleUser.Where(i => i.UserID == userId);

            if (userRolequery != null)
            {
                var userRoles = (from r in userRolequery
                                 select new RoleItemModel
                                 {
                                     Id = r.RoleID
                                 }).ToList();
                return userRoles;
            }
            return null;
        }
        public List<RoleItemModel> GetUserRoles(int userId)
        {
            var userRolequery = context.Common_Authen_RoleUser.Where(i => i.UserID == userId && (i.Common_Authen_Role.ShowFlag.Value == true || i.Common_Authen_Role.ShowFlag.HasValue == false));

            if (userRolequery != null)
            {
                var userRoles = (from r in userRolequery
                                 select new RoleItemModel
                                 {
                                     RoleName = r.Common_Authen_Role.ResourceKey
                                 }).ToList();
                return userRoles;
            }
            return null;
        }

        #region IDisposable Implementation
        protected bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                // Do nothing if the object has already been disposed of.
                if (disposed)
                    return;
                if (disposing)
                {
                    // Release disposable objects used by this instance here.
                    if (context != null)
                        context.Dispose();
                }

                // Release unmanaged resources here. Don't access reference type fields.

                // Remember that the object has been disposed of.
                disposed = true;
            }
        }
        public virtual void Dispose()
        {
            Dispose(true);
            // Unregister object for finalization.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
