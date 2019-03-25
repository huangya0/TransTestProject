using AdminLteAspNetMVC1.Common;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PermissionControlAttribute());
        }
    }
}
