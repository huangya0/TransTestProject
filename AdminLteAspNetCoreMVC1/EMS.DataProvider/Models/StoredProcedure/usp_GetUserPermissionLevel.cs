using EMS.DataProvider.Common;
using EMS.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProvider.Models.StoredProcedure
{
    [StoredProcedureName("usp_GetUserPermissionLevel")]
    public class usp_GetUserPermissionLevel : SPBase
    {
        [Parameter("UserID", TypeName = "int")]
        public int UserID { get; set; }
    }
}
