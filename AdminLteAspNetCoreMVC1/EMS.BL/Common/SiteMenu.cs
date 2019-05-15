using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VM = EMS.Model;
using CTX = EMS.DataProvider.Contexts;
using MD = EMS.DataProvider.Models.Common;

namespace EMS.BL.Common
{
    public class SiteMenu : IDisposable
    {
        private readonly CTX.EmsWebDB ctx;

        public SiteMenu()
        {
            ctx = new CTX.EmsWebDB();
        }

        private List<VM.Common.SiteMenu> FillVM(IQueryable<MD.Common_SiteMap_Menu> query)
        {
            return (from m in query
                    select new VM.Common.SiteMenu()
                    {
                        MenuID = m.MenuID,
                        ParentID = m.ParentID,
                        ResourceKey = m.ResourceKey,
                        Area = m.Area,
                        Controller = m.Controller,
                        ActionName = m.ActionName,
                        RouteValues = m.RouteValues,
                        IsSkip = m.IsSkip,
                        DisplayOrder = m.DisplayOrder
                    }).ToList();
        }

        public List<VM.Common.SiteMenu> GetAllMenu()
        {
            var query = from m in ctx.Common_SiteMap_Menu
                        select m;
            var result = FillVM(query);
            return result;
        }

        public List<VM.Common.SiteMenu> GetSiteMenu(int userID)
        {
            List<MD.vw_Authen_RolePermissions> rolePermissions = GetRolePermission(userID);

            List<MD.Common_SiteMap_Menu> siteMenus = ctx.Common_SiteMap_Menu.Where(p => !p.ParentID.HasValue && p.IsShow.HasValue && p.IsShow.Value).OrderBy(p => p.DisplayOrder).ToList();

            List<VM.Common.SiteMenu> vwSiteMenus = ConvertSiteMenu(siteMenus);

            ProcessSiteMenuByRoleRecursion(vwSiteMenus, rolePermissions);


            return vwSiteMenus;
        }

        public List<VM.Common.SiteMenu> GetSiteMenu(int userID, List<VM.Common.SiteMenu> siteMenus)
        {
            List<MD.vw_Authen_RolePermissions> rolePermissions = GetRolePermission(userID);

            if (rolePermissions != null)
            {
                rolePermissions.ForEach(p =>
                {
                    p.Area = string.IsNullOrWhiteSpace(p.Area) ? string.Empty : p.Area;
                    p.Controller = string.IsNullOrWhiteSpace(p.Controller) ? string.Empty : p.Controller;
                    p.ActionName = string.IsNullOrWhiteSpace(p.ActionName) ? string.Empty : p.ActionName;
                });
            }

            ProcessSiteMenuByRoleRecursion(siteMenus, rolePermissions);

            return siteMenus;
        }

        private void ProcessSiteMenuByRoleRecursion(List<VM.Common.SiteMenu> siteMenus, List<MD.vw_Authen_RolePermissions> rolePermissions)
        {
            for (int i = siteMenus.Count() - 1; i >= 0; i--)
            {
                if (siteMenus[i].ChildrenMenu == null || siteMenus[i].ChildrenMenu.Count == 0)
                {
                    if (!siteMenus[i].IsSkip && !IsExists(siteMenus[i], rolePermissions, i))
                    {
                        siteMenus.RemoveAt(i);
                    }
                }
                else
                {
                    ProcessSiteMenuByRoleRecursion(siteMenus[i].ChildrenMenu, rolePermissions);
                    if (!siteMenus[i].IsSkip && siteMenus[i].ChildrenMenu.Count() == 0 && !IsExists(siteMenus[i], rolePermissions, i))
                    {
                        siteMenus.RemoveAt(i);
                    }
                }
            }
        }

        private bool IsExists(VM.Common.SiteMenu siteMenu, List<MD.vw_Authen_RolePermissions> rolePermissions, int i)
        {
            return rolePermissions.Any(p =>
            {
                //HasActionPermission
                if (p.HasActionPermission)  //add by zack 20190325
                {
                    if (p.Area.Equals(siteMenu.Area, StringComparison.InvariantCultureIgnoreCase) &&
                    p.Controller.Equals(siteMenu.Controller, StringComparison.InvariantCultureIgnoreCase) &&
                    p.ActionName.Equals(siteMenu.ActionName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //add by zack 20190325
                    if (p.Area.Equals(siteMenu.Area, StringComparison.InvariantCultureIgnoreCase) &&
                    p.Controller.Equals(siteMenu.Controller, StringComparison.InvariantCultureIgnoreCase) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            });

        }

        private List<MD.vw_Authen_RolePermissions> GetRolePermission(int userID)
        {
            //CTX.Commom.TrainingCenterContext ctxPermissions = new CTX.Commom.TrainingCenterContext();
            List<MD.vw_Authen_RolePermissions> rolePermissions = (from r in ctx.vw_Authen_RolePermissions
                                                                  join u in ctx.Common_Authen_RoleUser
                                                       on r.RoleID equals u.RoleID
                                                                  where u.UserID == userID
                                                                  select r).ToList();
            //ctxPermissions.Dispose();
            return rolePermissions;
        }

        private List<VM.Common.SiteMenu> ConvertSiteMenu(List<MD.Common_SiteMap_Menu> siteMenus)
        {
            List<VM.Common.SiteMenu> vwSiteMenus = null;

            if (siteMenus != null)
            {
                var siteMenusOrder = siteMenus.OrderBy(p => p.DisplayOrder);
                vwSiteMenus = new List<VM.Common.SiteMenu>();
                foreach (MD.Common_SiteMap_Menu siteMenu in siteMenusOrder)
                {
                    vwSiteMenus.Add(new VM.Common.SiteMenu
                    {
                        ActionName = string.IsNullOrEmpty(siteMenu.ActionName) ? string.Empty : siteMenu.ActionName,
                        Area = string.IsNullOrEmpty(siteMenu.Area) ? string.Empty : siteMenu.Area,
                        Controller = string.IsNullOrEmpty(siteMenu.Controller) ? string.Empty : siteMenu.Controller,
                        MenuID = siteMenu.MenuID,
                        ParentID = siteMenu.ParentID,
                        ResourceKey = string.IsNullOrEmpty(siteMenu.ResourceKey) ? string.Empty : siteMenu.ResourceKey,
                        RouteValues = string.IsNullOrEmpty(siteMenu.RouteValues) ? string.Empty : siteMenu.RouteValues,
                        IsSkip = siteMenu.IsSkip,
                        DisplayOrder = siteMenu.DisplayOrder,
                        ChildrenMenu = ConvertSiteMenu(siteMenu.ChildrenMenu.Where(p => p.IsShow.Value).ToList())
                    });
                }
            }

            return vwSiteMenus;
        }

        public static List<VM.Common.SiteMenu> CloneSiteMenu(List<VM.Common.SiteMenu> siteMenus)
        {
            List<VM.Common.SiteMenu> TranscriptSiteMenus = null;

            if (siteMenus != null)
            {
                TranscriptSiteMenus = new List<VM.Common.SiteMenu>();
                siteMenus.ForEach(p => TranscriptSiteMenus.Add(new VM.Common.SiteMenu
                {
                    ActionName = p.ActionName,
                    Area = p.Area,
                    Controller = p.Controller,
                    DisplayOrder = p.DisplayOrder,
                    IsSkip = p.IsSkip,
                    MenuID = p.MenuID,
                    ParentID = p.ParentID,
                    ResourceKey = p.ResourceKey,
                    RouteValues = p.RouteValues,
                    ChildrenMenu = CloneSiteMenu(p.ChildrenMenu)
                }));
            }
            return TranscriptSiteMenus;
        }

        public List<VM.Common.SiteMenu> GetSiteMenu()
        {
            List<MD.Common_SiteMap_Menu> siteMenus = ctx.Common_SiteMap_Menu.Where(p => p.IsShow.Value).OrderBy(p => p.DisplayOrder).ToList();
            List<VM.Common.SiteMenu> vwSiteMenus = null;

            if (siteMenus != null && siteMenus.Count > 0)
            {
                vwSiteMenus = ConvertToVMMenu(siteMenus.Where(p => !p.ParentID.HasValue || (p.ParentID.HasValue && !siteMenus.Exists(m => m.MenuID == p.ParentID.Value))), null);
                vwSiteMenus.ForEach(p => p.ChildrenMenu = GetChildMenu(p, siteMenus));

                //vwSiteMenus = (from p in siteMenus
                //              where !p.ParentID.HasValue || (p.ParentID.HasValue && !siteMenus.Exists(m => m.MenuID == p.ParentID.Value))
                //              select new VM.SiteMenu
                //              {
                //                  ActionName = string.IsNullOrEmpty(p.ActionName) ? string.Empty : p.ActionName,
                //                  Area = string.IsNullOrEmpty(p.Area) ? string.Empty : p.Area,
                //                  Controller = string.IsNullOrEmpty(p.Controller) ? string.Empty : p.Controller,
                //                  MenuID = p.MenuID,
                //                  ParentID = p.ParentID,
                //                  ResourceKey = string.IsNullOrEmpty(p.ResourceKey) ? string.Empty : p.ResourceKey,
                //                  RouteValues = string.IsNullOrEmpty(p.RouteValues) ? string.Empty : p.RouteValues,
                //                  IsSkip = p.IsSkip,
                //                  DisplayOrder = p.DisplayOrder,
                //                  ChildrenMenu = GetChildMenu(p.MenuID, siteMenus)
                //              }).OrderBy(p=>p.DisplayOrder).ToList();                               
            }

            return vwSiteMenus;
        }

        //public List<VM.Common.SiteMenu> GetFrontDynamicSiteMenu(VM.UserModel user)
        //{
        //    List<VM.Common.SiteMenu> frontMenus = new List<VM.Common.SiteMenu>();
        //    if (user != null && user.RoleList != null)
        //    {
        //        if (user.RoleList.Contains((int)RoleID.SystemAdmin))
        //        {
        //            frontMenus.Add(new VM.Common.SiteMenu() { ResourceKey = CommonResource.Menu_Front_SysManagement, Area = "BackEndHome", Controller = "TIHome", ActionName = "Index" });
        //        }
        //        if (user.RoleList.Contains((int)RoleID.TCAdmin))
        //        {
        //            frontMenus.Add(new VM.Common.SiteMenu() { ResourceKey = CommonResource.Menu_Front_TCManagement, Area = "BackEndHome", Controller = "TIHome", ActionName = "Index" });
        //        }
        //    }
        //    return frontMenus;
        //}

        private List<VM.Common.SiteMenu> GetChildMenu(VM.Common.SiteMenu parentMenu, List<MD.Common_SiteMap_Menu> siteMenus)
        {
            List<VM.Common.SiteMenu> vwSiteMenus = null;
            if (siteMenus != null && siteMenus.Count > 0)
            {
                vwSiteMenus = ConvertToVMMenu(siteMenus.Where(p => p.ParentID.HasValue && p.ParentID.Value == parentMenu.MenuID), parentMenu);
                vwSiteMenus.ForEach(p => p.ChildrenMenu = GetChildMenu(p, siteMenus));

                //vwSiteMenus = (from p in siteMenus
                //               where p.ParentID.Value==parentID
                //               select new VM.SiteMenu
                //               {
                //                   ActionName = string.IsNullOrEmpty(p.ActionName) ? string.Empty : p.ActionName,
                //                   Area = string.IsNullOrEmpty(p.Area) ? string.Empty : p.Area,
                //                   Controller = string.IsNullOrEmpty(p.Controller) ? string.Empty : p.Controller,
                //                   MenuID = p.MenuID,
                //                   ParentID = p.ParentID,
                //                   ResourceKey = string.IsNullOrEmpty(p.ResourceKey) ? string.Empty : p.ResourceKey,
                //                   RouteValues = string.IsNullOrEmpty(p.RouteValues) ? string.Empty : p.RouteValues,
                //                   IsSkip = p.IsSkip,
                //                   DisplayOrder = p.DisplayOrder,
                //                   ChildrenMenu=GetChildMenu(p.MenuID,siteMenus)
                //               }).OrderBy(p => p.DisplayOrder).ToList();
            }
            return vwSiteMenus;
        }

        private List<VM.Common.SiteMenu> ConvertToVMMenu(IEnumerable<MD.Common_SiteMap_Menu> siteMenus, VM.Common.SiteMenu parentMenu)
        {
            List<VM.Common.SiteMenu> vwSiteMenus = (from p in siteMenus
                                                    select new VM.Common.SiteMenu
                                                    {
                                                        ActionName = string.IsNullOrEmpty(p.ActionName) ? string.Empty : p.ActionName,
                                                        Area = string.IsNullOrEmpty(p.Area) ? string.Empty : p.Area,
                                                        Controller = string.IsNullOrEmpty(p.Controller) ? string.Empty : p.Controller,
                                                        MenuID = p.MenuID,
                                                        ParentID = p.ParentID,
                                                        ParentMenu = parentMenu,
                                                 ResourceKey = string.IsNullOrEmpty(p.ResourceKey) ? string.Empty : p.ResourceKey,
                                                 RouteValues = string.IsNullOrEmpty(p.RouteValues) ? string.Empty : p.RouteValues,
                                                 IsSkip = p.IsSkip,
                                                 DisplayOrder = p.DisplayOrder
                                             }).OrderBy(p => p.DisplayOrder).ToList();
            return vwSiteMenus;
        }

        #region IDisposable Member
        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
        }
        #endregion
    }
}
