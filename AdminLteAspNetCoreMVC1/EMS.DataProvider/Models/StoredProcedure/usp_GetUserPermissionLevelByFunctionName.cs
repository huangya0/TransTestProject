using EMS.DataProvider.Common;
using EMS.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProvider.Models.StoredProcedure
{
    [StoredProcedureName("usp_GetUserPermissionLevelByFunctionName")]
    public class usp_GetUserPermissionLevelByFunctionName : SPBase
    {
        [Parameter("UserID", TypeName = "int")]
        public int UserID { get; set; }
        [Parameter("FunctionName", TypeName = "varchar", Length = 100)]
        public string FunctionName { get; set; }
    }
}
