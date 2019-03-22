using EMS.BL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM = EMS.Model;

namespace EMS.BL
{
    public interface ISampleBL : IMessageModel, IDisposable
    {
        IQueryable<VM.SampleItemModel> GetSampleList();
    }
}
