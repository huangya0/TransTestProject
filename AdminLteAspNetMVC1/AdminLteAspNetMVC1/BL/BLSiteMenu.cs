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
            List<VM.SiteMenu> childMenu2 = new List<VM.SiteMenu>()
                                                    {
                                                        new VM.SiteMenu() { MenuID=8, ParentID=6, ResourceKey="Contact Async", Area="", Controller="Home", ActionName="Contact", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=9, ParentID=6, ResourceKey="About", Area="", Controller="Home", ActionName="About", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                        new VM.SiteMenu() { MenuID=10, ParentID=6, ResourceKey="Home", Area="", Controller="Home", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                    };

            List<VM.SiteMenu> childMenu1 = new List<VM.SiteMenu>()
                                                    {
                                                        new VM.SiteMenu() { MenuID=5, ParentID=4, ResourceKey="Contact Async", Area="", Controller="Home", ActionName="Contact", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=6, ParentID=4, ResourceKey="About", Area="", Controller="Home", ActionName="About", RouteValues="", IsSkip=false, DisplayOrder=2, ChildrenMenu=childMenu2},
                                                        new VM.SiteMenu() { MenuID=7, ParentID=4, ResourceKey="Home", Area="", Controller="Home", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                    };

            List<VM.SiteMenu> returnVal = new List<VM.SiteMenu>()
                                                    {
                                                        new VM.SiteMenu() { MenuID=1, ParentID=null, ResourceKey="Contact Async", Area="", Controller="Home", ActionName="Contact", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=2, ParentID=null, ResourceKey="About", Area="", Controller="Home", ActionName="About", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                        new VM.SiteMenu() { MenuID=3, ParentID=null, ResourceKey="Home", Area="", Controller="Home", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3},
                                                        new VM.SiteMenu() { MenuID=4, ParentID=null, ResourceKey="MultiLeveMenu", Area="", Controller="", ActionName="", RouteValues="", IsSkip=false, DisplayOrder=4, ChildrenMenu=childMenu1}
                                                    };


            return returnVal;
        }
    }
}