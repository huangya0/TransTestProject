using AdminLteAspNetMVC1.BL;
using System.Collections.Generic;
using System.Web;
using VM = AdminLteAspNetMVC1.ViewModel;

namespace AdminLteAspNetMVC1.Common
{
    public static class SiteMenuHelper
    {
        private const string CACHE_KEY = "SiteMenus";
        public static List<VM.SiteMenu> GetSiteMenu()
        {
            List<VM.SiteMenu> siteMenus = HttpContext.Current.Cache[CACHE_KEY] as List<VM.SiteMenu>;
            if (siteMenus == null || siteMenus.Count<=0)
            {
                int userID = -1;
                siteMenus = BLSiteMenu.GetSiteMenu(userID);
                HttpContext.Current.Cache.Insert(CACHE_KEY, siteMenus);
            }
            return siteMenus;
        }


    }
}