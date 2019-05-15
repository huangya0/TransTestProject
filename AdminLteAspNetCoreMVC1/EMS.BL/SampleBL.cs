using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.BL.Common;
using EMS.DataProvider.Contexts;
using MD = EMS.DataProvider.Models;
using VM = EMS.Model;
using EMS.Model.Common;
//using System.Data.Entity;
using EMS.GlobalResources;
using Microsoft.EntityFrameworkCore;

namespace EMS.BL
{
    public class SampleBL : BaseBusinessLogic, ISampleBL
    {
        //public MessageModel Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public event MessageEventHandler SetMessage;

        private readonly EmsWebDB context;
        public SampleBL()
        {
            context = new EmsWebDB();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public IQueryable<VM.SampleItemModel> GetSampleList()
        {
            IQueryable<MD.tbl_Sample> resultQueryable;
            resultQueryable = context.tbl_Sample.Where(i => i.ID > 0);
            var result = resultQueryable.Select(i => new VM.SampleItemModel()
            {
                //转换有业务的在这进行处理
                Id = i.ID,
                Name = i.Name,
                Address = i.Address,
                CreatedBy = i.CreatedBy,
                //UpdatedDate = DbFunctions.TruncateTime(i.UpdatedDate),
                UpdatedDate = i.UpdatedDate,
                CreatedDate = i.CreatedDate??System.DateTime.Now, //.GetValueOrDefault(),
                UpdatedBy = i.UpdatedBy

            });
            return result;

        }

        public bool IsExistRecord(VM.SampleItemModel model)
        {
            return context.tbl_Sample.Any(i => i.Name == model.Name && i.IsDeleted == false);
        }

        public bool CreateSampleItem(VM.SampleItemModel model)
        {
            if (model == null)
            {
                //Message = MessageModel.InsertFailue(MessageResource.QualificaitonPage_Empty_ErrorMessage + "," + MessageResource.Message_CommonInsertFail);
                Message = MessageModel.InsertFailue(MessageResource.Message_CommonInsertFail);
                return false;
            }
            var item = this.ConvertToDataModel(model);
            context.tbl_Sample.Add(item);
            context.SaveChanges();
            Message = MessageModel.InsertSuccess();
            return true;
        }


        private MD.tbl_Sample ConvertToDataModel(VM.SampleItemModel model)
        {
            if (model == null)
            {
                return null;
            }
            MD.tbl_Sample item = new MD.tbl_Sample();
            item.ID = model.Id;
            item.Name = model.Name;
            item.Address = model.Address;
            item.IsDeleted = false;

            item.CreatedBy = model.CreatedBy;
            item.CreatedDate = model.CreatedDate;
            item.UpdatedBy = model.UpdatedBy;
            item.UpdatedDate = model.UpdatedDate;
            return item;
        }

    }
}
