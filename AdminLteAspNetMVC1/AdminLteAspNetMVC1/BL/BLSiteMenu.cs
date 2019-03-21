using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VM = AdminLteAspNetMVC1.ViewModel;

namespace AdminLteAspNetMVC1.BL
{
    public class BLSiteMenu
    {
        public static List<VM.SiteMenu> GetSiteMenu(int userID)
        {
            List<VM.SiteMenu> returnVal = new List<VM.SiteMenu>()
                                                    {
                                                        new VM.SiteMenu() { MenuID=1, ParentID=null, ResourceKey="Contact", Area="", Controller="Home", ActionName="Contact", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=2, ParentID=null, ResourceKey="About", Area="", Controller="Home", ActionName="About", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                        new VM.SiteMenu() { MenuID=3, ParentID=null, ResourceKey="Home", Area="", Controller="Home", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                    };


            return returnVal;
        }
    }
}