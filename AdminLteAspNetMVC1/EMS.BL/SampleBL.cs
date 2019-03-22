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
using System.Data.Entity;

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
                UpdatedDate = DbFunctions.TruncateTime(i.UpdatedDate),
                CreatedDate = DbFunctions.TruncateTime(i.CreatedDate),
                UpdatedBy = i.UpdatedBy

            });
            return result;

        }
    }
}
