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
                                                        new VM.SiteMenu() { MenuID=8, ParentID=6, ResourceKey="Level3_1", Area="", Controller="Home", ActionName="MenuLevel3_1", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=9, ParentID=6, ResourceKey="Level3_2", Area="", Controller="Home", ActionName="MenuLevel3_2", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                        new VM.SiteMenu() { MenuID=10, ParentID=6, ResourceKey="Level3_3", Area="", Controller="Sample", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                    };

            List<VM.SiteMenu> childMenu1 = new List<VM.SiteMenu>()
                                                    {
                                                        new VM.SiteMenu() { MenuID=5, ParentID=4, ResourceKey="Level2_1", Area="", Controller="Home", ActionName="MenuLevel2_1", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                        new VM.SiteMenu() { MenuID=6, ParentID=4, ResourceKey="Level2_2", Area="", Controller="Home", ActionName="MenuLevel2_2", RouteValues="", IsSkip=false, DisplayOrder=2, ChildrenMenu=childMenu2},
                                                        new VM.SiteMenu() { MenuID=7, ParentID=4, ResourceKey="Level2_3", Area="", Controller="Home", ActionName="MenuLevel2_3", RouteValues="", IsSkip=false, DisplayOrder=3}
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