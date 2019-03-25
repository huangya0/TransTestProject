//using AdminLteAspNetMVC1.BL;

using System.Collections.Generic;
using System.Web;
using VM = EMS.Model.Common;
using EMS.BL.Common;

namespace AdminLteAspNetMVC1.Common
{
    public static class SiteMenuHelper
    {
        private const string CACHE_KEY = "SiteMenus";
        private static List<VM.SiteMenu> GetAllSiteMenu()
        {
            List<VM.SiteMenu> siteMenus = HttpContext.Current.Cache[CACHE_KEY] as List<VM.SiteMenu>;
            if (siteMenus == null || siteMenus.Count<=0)
            {
                //int userID = -1;

                var blSiteMenu = new SiteMenu();
                siteMenus = blSiteMenu.GetSiteMenu();
                blSiteMenu.Dispose();
                if (siteMenus != null)
                {
                    //HttpContext.Current.Cache.Insert(CACHE_KEY, siteMenus);
                }
            }
            return SiteMenu.CloneSiteMenu(siteMenus);
        }

        public static List<VM.SiteMenu> GetSiteMenu()
        {
            int userID = -1;
            var userInfo = UserHelper.GetCurrentUser();
            if (userInfo != null)
            {
                userID = userInfo.ID;
            }

            using (var bl = new SiteMenu())
            {
                return bl.GetSiteMenu(userID, GetAllSiteMenu());
            }

        }

    }
}