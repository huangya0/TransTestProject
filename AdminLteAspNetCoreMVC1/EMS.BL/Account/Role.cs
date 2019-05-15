using EMS.BL.Common;
using EMS.DataProvider.Contexts;
using EMS.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VM = EMS.Model.Role;
using MD = EMS.DataProvider.Models.Common;
using EMS.Model.Common;
using EMS.GlobalResources;
using Microsoft.EntityFrameworkCore;

namespace EMS.BL.Account
{
    public class Role : BaseBusinessLogic, IDisposable
    {
        private readonly EmsWebDB ctx;

        public Role()
        {
            ctx = new EmsWebDB();
        }

        public VM.RoleItemModel GetRole(int id)
        {
            MD.Common_Authen_Role role = ctx.Common_Authen_Role.First(i => i.RoleID == id);
            if (role != null)
            {
                return this.ConvertViewModel(role);
            }
            return null;
        }

        public List<VM.RoleItemModel> GetRoleList()
        {
            return this.ConvertViewModelList(ctx.Common_Authen_Role.Take(10));
        }

        public List<VM.RoleItemModel> GetRoleList(VM.RoleSearchModel search)
        {
            Expression<Func<MD.Common_Authen_Role, bool>> expr = null;
            string sortBy = "RoleName";
            string sortDirection = "DESC";
            if (string.IsNullOrWhiteSpace(search.SortBy))
            {
                search.SortBy = sortBy;
                search.SortDirection = sortDirection;
            }
            IQueryable<MD.Common_Authen_Role> resultQuery = null;
            expr = this.BuildSearchCriteria(search);
            if (expr == null)
            {
                resultQuery = ctx.Common_Authen_Role.SortWith(search.SortBy, search.SortDirection);
            }
            else
            {
                resultQuery = ctx.Common_Authen_Role.Where(expr).SortWith(search.SortBy, search.SortDirection);
            }
            search.RecordCount = resultQuery.Count();
            resultQuery = resultQuery.Skip(search.PageSkip).Take(search.PageSize);
            Message = new MessageModel() { IsSuccess = true, MessageType = Model.Common.MessageType.SelectSuccess, Message = MessageResource.Message_CommonLoadSuccessful };
            return this.ConvertViewModelList(resultQuery);
        }

        public void CreateRole(VM.RoleItemModel role)
        {
            MessageModel message = null;

            if (role == null)
            {
                message = new MessageModel() { IsSuccess = false, Message = MessageResource.Role_Empty_ErrorMessage + "," + MessageResource.Message_CommonUpdateFail, MessageType = MessageType.InsertFailure };
                return;
            }
            if (ctx.Common_Authen_Role.Any(i => i.RoleName == role.RoleName))
            {
                message = new MessageModel() { IsSuccess = false, MessageType = MessageType.InsertFailure, Message = MessageResource.Role_Exits_ErrorMessage + "," + MessageResource.Message_CommonUpdateFail };
                return;
            }

            var maxId = ctx.Common_Authen_Role.Max(b => b.RoleID) + 1;
            var mdRole = this.ConvertDataModel(role);
            mdRole.ShowFlag = true;
            mdRole.RoleID = maxId;
            ctx.Common_Authen_Role.Add(mdRole);
            ctx.SaveChanges();
            message = new MessageModel() { IsSuccess = true, MessageType = MessageType.InsertSuccess, Message = MessageResource.Message_CommonInsertSuccessful };

            Message = message;
        }

        public void UpdateRole(VM.RoleItemModel role)
        {
            MessageModel message = null;
            if (role == null)
            {
                message = new MessageModel() { IsSuccess = false, Message = MessageResource.Role_Empty_ErrorMessage + "," + MessageResource.Message_CommonUpdateFail, MessageType = MessageType.UpdateFailure };
                return;
            }
            if (!ctx.Common_Authen_Role.Any(i => i.RoleID == role.Id))
            {
                message = new MessageModel() { IsSuccess = false, MessageType = MessageType.UpdateFailure, Message = MessageResource.Role_Exits_ErrorMessage + "," + MessageResource.Message_CommonUpdateFail };
                return;
            }
            MD.Common_Authen_Role temp = ctx.Common_Authen_Role.First(i => i.RoleID == role.Id);
            temp.RoleName = role.RoleName;
            temp.Description = role.Description;
            ctx.SaveChanges();
            message = new MessageModel() { IsSuccess = true, MessageType = MessageType.UpdateSuccess, Message = MessageResource.Message_CommonUpdateSuccessful };

            Message = message;
        }

        public void DeleteRole(int id)
        {
            if (id == 0)
            {
                Message = new MessageModel() { IsSuccess = false, MessageType = MessageType.DeleteFailure, Message = MessageResource.Role_Empty_ErrorMessage + "," + MessageResource.Message_CommonDeleteFail };
                return;
            }
            if (!ctx.Common_Authen_Role.Any(i => i.RoleID == id))
            {
                Message = new MessageModel() { IsSuccess = false, MessageType = MessageType.DeleteFailure, Message = MessageResource.Role_Exits_ErrorMessage + "," + MessageResource.Message_CommonDeleteFail };
                return;
            }
            if (ctx.Common_Authen_RoleUser.Count(ru => ru.RoleID == id) > 0)
            {
                Message = new MessageModel() { IsSuccess = false, MessageType = MessageType.DeleteFailure, Message = MessageResource.Role_RemoveUser_ErrorMessage };
                return;
            }
            var mdRole = ctx.Common_Authen_Role.FirstOrDefault(i => i.RoleID == id);
            ctx.Common_Authen_Role.Remove(mdRole);
            ctx.SaveChanges();
            Message = new MessageModel() { IsSuccess = true, MessageType = MessageType.DeleteSuccess, Message = MessageResource.Message_CommonDeleteSuccessful };
        }

        public int GetRoleId(string userName)
        {
            var user = ctx.Common_Authen_User.Include("Common_Authen_RoleUser").SingleOrDefault(u => u.LogonName == userName);// && u.IsDeleted == false);
            return ctx.Common_Authen_RoleUser.FirstOrDefault(i => i.UserID == user.UserID).RoleID;

        }

        public Dictionary<int, string> GetUserRoleMsg(int userId)
        {
            var user = ctx.Common_Authen_User.Include("Common_Authen_RoleUser").SingleOrDefault(u => u.UserID == userId); // && u.IsDeleted == false);
            var result = new Dictionary<int, string>();
            foreach (var role in user.Common_Authen_RoleUser)
            {
                result.Add(role.RoleID, role.Common_Authen_Role.RoleName);
            }
            return result;
        }


        #region ======Common Methods======

        private VM.RoleItemModel ConvertViewModel(MD.Common_Authen_Role role)
        {
            if (role == null)
            {
                return null;
            }
            return new VM.RoleItemModel()
            {
                Id = role.RoleID,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        private MD.Common_Authen_Role ConvertDataModel(VM.RoleItemModel role)
        {
            if (role == null)
            {
                return null;
            }
            return new MD.Common_Authen_Role()
            {
                RoleID = role.Id,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        private List<VM.RoleItemModel> ConvertViewModelList(IQueryable<MD.Common_Authen_Role> queryResult)
        {
            List<VM.RoleItemModel> result = new List<VM.RoleItemModel>();
            foreach (var role in queryResult)
            {
                result.Add(ConvertViewModel(role));
            }
            return result;
        }

        private Expression<Func<MD.Common_Authen_Role, bool>> BuildSearchCriteria(VM.RoleSearchModel search)
        {
            Expression<Func<MD.Common_Authen_Role, bool>> expr = null;
            DynamicLambda<MD.Common_Authen_Role> bulid = new DynamicLambda<MD.Common_Authen_Role>();
            if (!string.IsNullOrEmpty(search.RoleName))
            {
                Expression<Func<MD.Common_Authen_Role, bool>> temp = s => s.RoleName.Contains(search.RoleName);
                expr = bulid.BuildQueryAnd(expr, temp);
            }
            return expr;
        }

        #endregion

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
        }
    }
}
