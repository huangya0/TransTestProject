using EMS.BL.Common;
using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteAspNetMVC1.Common
{
    public class PermissionDataHelper
    {
        
        private const string CACHE_KEY = "PermissionCaching";

        public static List<PermissionItem> GetPermissionData()
        {
            var result = HttpContext.Current.Cache[CACHE_KEY] as List<PermissionItem>;
            if (result == null)
            {
                result = RefreshCacheData();
            }
#if debug
    result = RefreshCacheData();
#endif

            return result;
        }

        public static List<PermissionItem> RefreshCacheData()
        {
            List<PermissionItem> result;
            using (var permissionBL = new Permission())
            {
                result = permissionBL.GetPermissions();
                HttpContext.Current.Cache.Insert(CACHE_KEY, result);
            }
            return result;
        }   
    }
}