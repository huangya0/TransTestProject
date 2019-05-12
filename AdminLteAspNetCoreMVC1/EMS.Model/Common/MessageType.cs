using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public enum MessageType
    {
        Success,
        Failure,
        InsertSuccess,
        InsertFailure,
        UpdateSuccess,
        UpdateFailure,
        DeleteSuccess,
        DeleteFailure,
        SelectSuccess,
        SelectFailure,
        ValidFailure,
        ExportSuccess,
        ExportFailure,
        Other
    }
}
