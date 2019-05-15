using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VM = EMS.Model;
using CTX = EMS.DataProvider.Contexts;
using MD = EMS.DataProvider.Models;
using EMS.Utility.DEncrypt;
using Microsoft.EntityFrameworkCore;

namespace EMS.BL.Common
{
    public class Permission : IDisposable
    {
        private readonly CTX.EmsWebDB ctx;

        public Permission()
        {
            ctx = new CTX.EmsWebDB();
        }

        public List<VM.Common.PermissionItem> GetPermissions()
        {
            var query = from p in ctx.vw_Authen_RolePermissions
                        orderby p.Area, p.Controller, p.HasActionPermission, p.ActionName
                        select p;
            var items = query.ToList();
            var permissions = ConvertToPermissionViewModel(items);
            return permissions;
        }

        public VM.Common.UserItem GetUser(int userID)
        {
            var user = ctx.Common_Authen_User.Include("Common_Authen_RoleUser").SingleOrDefault(u => u.UserID == userID);
            return ConvertUser(user);

        }

        public VM.Common.UserItem ValidUser(VM.LoginModel loginUser)
        {
            var userpwd = DESEncrypt.Encrypt(loginUser.Password); //PRD
            //var userpwd = loginUser.Password; //Test
            var user = ctx.Common_Authen_User.FirstOrDefault(m => m.LogonName == loginUser.LoginName && m.Password == userpwd && m.Status == 1);
            if (user != null)
            {
                var userId = user.UserID;
                var model = GetUser(user.UserID);

                //if (this.ctx.Common_Authen_RoleUser.Any(i => i.RoleID == RoleID.Student && i.UserID == userId))
                //{
                //    model.IsSutdent = true;
                //}
                //if (this.ctx.Common_Authen_RoleUser.Any(i => i.RoleID == RoleID.Lecturer && i.UserID == userId))
                //{
                //    model.IsLecture = true;
                //}

                return model;
            }
            else
            {
                return null;
            }
        }


        public List<string> GetPermissionLevelListByFunctionName(int userID, string functionName)
        {
            var sp = new MD.StoredProcedure.usp_GetUserPermissionLevelByFunctionName()
            {
                UserID = userID,
                FunctionName = functionName
            };
            //var perms = ctx.InvokeStoredProcedure<MD.StoredProcedure.usp_GetUserPermissionLevelByFunctionName, VM.Common.PermissionLevel>(sp);
            /*
            ALTER PROCEDURE[dbo].[usp_GetUserPermissionLevelByFunctionName]
            @UserID int,
            @FunctionName varchar(100)
            AS
                BEGIN
                -- SET NOCOUNT ON added to prevent extra result sets from
                -- interfering with SELECT statements.
                SET NOCOUNT ON;
            SELECT DISTINCT
            FPL.[FunctionName]
                , FPL.[PermissionLevel] AS[LevelName]
            FROM[dbo].[Common_Authen_RoleFunctionPermission]
            AS RFP
            INNER JOIN[dbo].[Common_Authen_FunctionPermissionLevel]
            AS FPL
            ON RFP.[PermissionLevelID] = FPL.ID
            INNER JOIN [dbo].[Common_Authen_RoleUser] AS ARU
            ON ARU.[RoleID] = RFP.[RoleID]
            WHERE ARU.[UserID] = @UserID AND FPL.[FunctionName] = @FunctionName
            END
            */

            var query = from fpl in ctx.Common_Authen_FunctionPermissionLevel
                join rfp in ctx.Common_Authen_RoleFunctionPermission on fpl.ID equals rfp.PermissionLevelID into pls
                from pl in pls
                join aru in ctx.Common_Authen_RoleUser on pl.RoleID equals aru.RoleID
                where aru.UserID == userID && fpl.FunctionName == functionName
                        select new VM.Common.PermissionLevel
                        {
                            ID = -1, //无用
                            Available = true, //无用
                            FunctionName = fpl.FunctionName,
                            LevelName = fpl.PermissionLevel
                        };

            var perms = query.ToList();

            var result = new List<string>();
            if (perms != null && perms.Count > 0)
            {
                foreach (var item in perms)
                {
                    result.Add(item.LevelName);
                }
            }
            return result;
        }

        public List<VM.Common.PermissionLevel> GetPermissionLevelList(int userID)
        {
            var sp = new MD.StoredProcedure.usp_GetUserPermissionLevel()
            {
                UserID = userID
            };
            //var perms = ctx.InvokeStoredProcedure<MD.StoredProcedure.usp_GetUserPermissionLevel, VM.Common.PermissionLevel>(sp);
            /*
            ALTER PROCEDURE[dbo].[usp_GetUserPermissionLevel]
            @UserID int
                AS
            BEGIN
                -- SET NOCOUNT ON added to prevent extra result sets from
                -- interfering with SELECT statements.
                SET NOCOUNT ON;
            SELECT DISTINCT
            FPL.[FunctionName]
                , FPL.[PermissionLevel] AS[LevelName]
            FROM[dbo].[Common_Authen_RoleFunctionPermission]
            AS RFP
            INNER JOIN[dbo].[Common_Authen_FunctionPermissionLevel]
            AS FPL
            ON RFP.[PermissionLevelID] = FPL.ID
            INNER JOIN [dbo].[Common_Authen_RoleUser] AS ARU
            ON ARU.[RoleID] = RFP.[RoleID]
            WHERE ARU.[UserID] = @UserID
            END
            */
            var perms = from fpl in ctx.Common_Authen_FunctionPermissionLevel
                        join rfp in ctx.Common_Authen_RoleFunctionPermission on fpl.ID equals rfp.PermissionLevelID into pls
                from pl in pls
                join aru in ctx.Common_Authen_RoleUser on pl.RoleID equals aru.RoleID
                        where aru.UserID == userID
                        select new VM.Common.PermissionLevel
                        {
                            ID = -1, //无用
                            Available = true, //无用
                            FunctionName = fpl.FunctionName,
                            LevelName = fpl.PermissionLevel
                        };

            return perms.ToList();
        }



        private List<VM.Common.PermissionItem> ConvertToPermissionViewModel(List<MD.Common.vw_Authen_RolePermissions> items)
        {
            var permissions = new List<VM.Common.PermissionItem>();
            var isFrist = true;
            VM.Common.PermissionItem permission = null;
            foreach (var item in items)
            {
                if (isFrist)
                {
                    permission = new VM.Common.PermissionItem();
                    isFrist = false;
                }
                else
                {
                    if (ComparePermissionItem(permission, item))
                    {
                        permission.RoleList.Add(item.RoleID);
                        continue;
                    }
                    else
                    {
                        permissions.Add(permission);
                        permission = new VM.Common.PermissionItem();
                    }
                }
                permission.Area = item.Area == null ? "" : item.Area.ToLowerInvariant();
                permission.Controller = item.Controller.ToLowerInvariant();
                permission.ActionName = item.ActionName.ToLowerInvariant();
                permission.HasActionPermission = item.HasActionPermission;
                permission.RoleList.Add(item.RoleID);
            }
            permissions.Add(permission);
            return permissions;
        }

        //public List<VM.SimpleData.RoleModel> GetUserRoles(int userId)
        //{
        //    var query = from p in _Context.RoleUser
        //                where p.UserID == userId
        //                select p.Role;
        //    var items = query.ToList();

        //    //Convert to view model
        //    var roleList = ConvertToRoleViewModel(items);
        //    return roleList;
        //}

        //public List<VM.SimpleData.RoleModel> GetRoleList()
        //{
        //    var query = from p in _Context.Role
        //                select p;
        //    var items = query.ToList();

        //    //Convert to view model
        //    var roleList = ConvertToRoleViewModel(items);
        //    return roleList;
        //}  

        //private List<VM.RoleModel> ConvertToRoleViewModel(List<MD.Common.Role> items)
        //{
        //    List<VM.RoleModel> roleList = null;
        //    if (items.Count > 0)
        //    {
        //        roleList = new List<VM.RoleModel>();
        //        foreach (var item in items)
        //        {
        //            var role = new VM.RoleModel();
        //            role.RoleID = item.ID;
        //            role.RoleName = item.RoleName;
        //            roleList.Add(role);
        //        }
        //    }
        //    return roleList;
        //}

        private bool ComparePermissionItem(VM.Common.PermissionItem x, MD.Common.vw_Authen_RolePermissions y)
        {
            if (x == null) return false;
            if (y == null) return false;
            if (string.Compare(x.Area, y.Area, true) != 0) return false;
            if (string.Compare(x.Controller, y.Controller, true) != 0) return false;
            if (string.Compare(x.ActionName, y.ActionName, true) != 0) return false;
            if (x.HasActionPermission != y.HasActionPermission) return false;
            return true;
        }

        private VM.Common.UserItem ConvertUser(MD.Common.Common_Authen_User user)
        {
            if (user == null) return null;
            var result = new VM.Common.UserItem();
            result.ID = user.UserID;
            result.LogonName = user.LogonName;
            result.FullName = user.UserName;
            foreach (var item in user.Common_Authen_RoleUser)
            {
                result.RoleList.Add(item.RoleID);
            }
            return result;
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
