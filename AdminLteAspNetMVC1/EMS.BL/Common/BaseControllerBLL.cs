using EMS.BL.Account;
using EMS.Model.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BL.Common
{
    /// <summary>
    /// 将一些公用的业务方法写在这里，供页面上的BaseController里调用
    /// </summary>
    public class BaseControllerBLL : IBaseControllerBLL
    {
        
        public string GetCompanyDateFormat(int companyId)
        {
            //using (Company companyBL = new Company())
            //{
            //    return companyBL.GetCompanyDateFormat(companyId);
            //}
            return string.Empty;
        }

        public int GetLongonUserRole(int id)
        {
            //using (User userBL = new User())
            //{
            //    return userBL.GetLongonUserRole(id);
            //}

            return 1;
        }

        public List<RoleItemModel> GetLongonUserRoles(int userId)
        {
            using (User userBL = new User())
            {
                return userBL.GetLongonUserRoles(userId);
            }
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
