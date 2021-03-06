﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.BL.Common;
using EMS.DataProvider.Contexts;
using MD = EMS.DataProvider.Models;
using VM = EMS.Model.User;
using EMS.Model.Common;
using System.Data.Entity;
using System.Linq.Expressions;
using EMS.Utility.Data;

namespace EMS.BL
{
    public class UserBL : BaseBusinessLogic, IUserBL
    {
        private readonly EmsWebDB context;

        //MessageModel IMessageModel.Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UserBL()
        {
            context = new EmsWebDB();
        }

        //event MessageEventHandler IMessageModel.SetMessage
        //{
        //    add
        //    {
        //        throw new NotImplementedException();
        //    }

        //    remove
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public IQueryable<VM.VmTblUser> GetUserList()
        {
            IQueryable<MD.Common.Common_Authen_User> resultQueryable;
            resultQueryable = context.Common_Authen_User.AsQueryable();
            var result = resultQueryable.Select(i => new VM.VmTblUser()
            {
                //转换有业务的在这进行处理
                UserID = i.UserID,
                LogonName = i.LogonName,
                Password = i.Password,
                UserName = i.UserName,
                Gender = i.Gender,
                PhoneNumber = i.PhoneNumber,
                EmailAddress = i.EmailAddress,
                IDNumber = i.IDNumber,
                DateOFBirth = i.DateOFBirth,
                Status = i.Status,
                CanDelete = i.CanDelete,

                CreatedBy = i.CreatedBy,
                UpdatedDate = DbFunctions.TruncateTime(i.UpdatedDate),
                CreatedDate = (System.DateTime)DbFunctions.TruncateTime(i.CreatedDate),
                UpdatedBy = i.UpdatedBy

            });
            return result;
        }

        public List<VM.VmTblUser> GetUserList(VM.UserSearchModel search)
        {
            string sortBy = "LogonName";
            string sortDirection = "DESC";
            if (string.IsNullOrWhiteSpace(search.SortBy))
            {
                search.SortBy = sortBy;
                search.SortDirection = sortDirection;
            }
            Expression<Func<MD.Common.Common_Authen_User, bool>> expr = this.BuildSearchCriteria(search);
            IQueryable<MD.Common.Common_Authen_User> resultQuery = context.Common_Authen_User.Where(expr).SortWith(search.SortBy, search.SortDirection);
            search.RecordCount = resultQuery.Count();
            resultQuery = resultQuery.Skip(search.PageSkip).Take(search.PageSize);
            Message = MessageModel.LoadSuccess();
            return this.ConvertToViewModelList(resultQuery);
        }

        private List<VM.VmTblUser> ConvertToViewModelList(IQueryable<MD.Common.Common_Authen_User> queryResult)
        {
            List<VM.VmTblUser> result = new List<VM.VmTblUser>();
            foreach (var item in queryResult)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }

        private Expression<Func<MD.Common.Common_Authen_User, bool>> BuildSearchCriteria(VM.UserSearchModel search)
        {
            Expression<Func<MD.Common.Common_Authen_User, bool>> expr = null;
            DynamicLambda<MD.Common.Common_Authen_User> bulid = new DynamicLambda<MD.Common.Common_Authen_User>();
            if (!string.IsNullOrEmpty(search.LogonName))
            {
                Expression<Func<MD.Common.Common_Authen_User, bool>> temp = s => s.LogonName.Contains(search.LogonName);
                expr = bulid.BuildQueryAnd(expr, temp);
            }
            Expression<Func<MD.Common.Common_Authen_User, bool>> solidFilter = s => (s.Status == 1);
            expr = bulid.BuildQueryAnd(expr, solidFilter);
            return expr;
        }

        public bool CreateUser(VM.VmTblUser model)
        {
            if (model == null)
            {
                //Message = MessageModel.InsertFailue(MessageResource.FaultCode_Empty_ErrorMessage + "," + MessageResource.Message_CommonInsertFail);
                Message = MessageModel.InsertFailue("页面对象为空！");
                return false;
            }
            var mdUser = this.ConvertToDataModel(model, null);
            context.Common_Authen_User.Add(mdUser);
            context.SaveChanges();
            Message = MessageModel.InsertSuccess();
            return true;
        }

        private MD.Common.Common_Authen_User ConvertToDataModel(VM.VmTblUser model, MD.Common.Common_Authen_User dbModel)
        {
            if (model == null)
            {
                return null;
            }
            if(dbModel == null)
            {
                //when update, will pass a dbModel into
                //MD.Common.Common_Authen_User 
                dbModel = new MD.Common.Common_Authen_User();
            }

            dbModel.UserID = model.UserID;
            dbModel.LogonName = model.LogonName;
            dbModel.Password = model.Password;
            dbModel.UserName = model.UserName;
            dbModel.Gender = model.Gender;
            dbModel.PhoneNumber = model.PhoneNumber;
            dbModel.EmailAddress = model.EmailAddress;
            dbModel.IDNumber = model.IDNumber;
            dbModel.DateOFBirth = model.DateOFBirth;
            dbModel.Status = model.Status;
            dbModel.CanDelete = model.CanDelete;

            dbModel.CreatedBy = model.CreatedBy;
            dbModel.UpdatedDate = model.UpdatedDate;
            dbModel.CreatedDate = model.CreatedDate;
            dbModel.UpdatedBy = model.UpdatedBy;

            return dbModel;
        }

        private VM.VmTblUser ConvertToViewModel(MD.Common.Common_Authen_User mdUser)
        {
            if (mdUser == null)
            {
                return null;
            }
            VM.VmTblUser vmModel = new VM.VmTblUser();
            vmModel.UserID = mdUser.UserID;
            vmModel.LogonName = mdUser.LogonName;
            vmModel.Password = mdUser.Password;
            vmModel.UserName = mdUser.UserName;
            vmModel.Gender = mdUser.Gender;
            vmModel.PhoneNumber = mdUser.PhoneNumber;
            vmModel.EmailAddress = mdUser.EmailAddress;
            vmModel.IDNumber = mdUser.IDNumber;
            vmModel.DateOFBirth = mdUser.DateOFBirth;
            vmModel.Status = mdUser.Status;
            vmModel.CanDelete = mdUser.CanDelete;

            vmModel.CreatedBy = mdUser.CreatedBy;
            vmModel.UpdatedDate = mdUser.UpdatedDate;
            vmModel.CreatedDate = mdUser.CreatedDate;
            vmModel.UpdatedBy = mdUser.UpdatedBy;
            return vmModel;
        }

        public VM.VmTblUser GetUserByLogonName(string logonName)
        {
            MD.Common.Common_Authen_User mdUser = context.Common_Authen_User.First(i => i.LogonName == logonName);
            if (mdUser != null)
            {
                return this.ConvertToViewModel(mdUser);
            }
            return null;
        }

        public VM.VmTblUser GetUserByID(int id)
        {
            MD.Common.Common_Authen_User mdUser = context.Common_Authen_User.First(i => i.UserID == id);
            if (mdUser != null)
            {
                return this.ConvertToViewModel(mdUser);
            }
            return null;
        }


        public bool UpdateUser(VM.VmTblUser model)
        {
            if (model == null)
            {
                Message = MessageModel.UpdateFailue("对象为空！");
                return false;
            }
            if (!context.Common_Authen_User.Any(i => i.UserID == model.UserID))
            {
                Message = MessageModel.UpdateFailue("目标对象不存在！");
                return false;
            }
            MD.Common.Common_Authen_User mdUser = context.Common_Authen_User.First(i => i.UserID == model.UserID);
            mdUser = this.ConvertToDataModel(model, mdUser);
            //context.Entry(mdUser).State = EntityState.Modified; //?
            context.SaveChanges();

            Message = MessageModel.UpdateSuccess();
            return true;
        }

        public bool DeleteUser(int id)
        {
            //if (model == null)
            //{
            //    Message = MessageModel.DeleteFailue("对象为空！");
            //    return false;
            //}
            if (!context.Common_Authen_User.Any(i => i.UserID == id))
            {
                Message = MessageModel.DeleteFailue("目标对象不存在！");
                return false;
            }
            MD.Common.Common_Authen_User mdUser = context.Common_Authen_User.First(i => i.UserID == id);
            //mdUser = this.ConvertToDataModel(model);
            context.Entry(mdUser).State = EntityState.Deleted; //?
            context.Common_Authen_User.Remove(mdUser);
            context.SaveChanges();

            Message = MessageModel.DeleteSuccess();
            return true;
        }

        public bool IsExistUser(VM.VmTblUser model)
        {
            return context.Common_Authen_User.Any(i => i.LogonName == model.LogonName);
        }
    }
}