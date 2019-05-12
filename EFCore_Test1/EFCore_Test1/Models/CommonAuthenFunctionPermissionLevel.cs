using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenFunctionPermissionLevel
    {
        public CommonAuthenFunctionPermissionLevel()
        {
            CommonAuthenControllerActions = new HashSet<CommonAuthenControllerActions>();
            CommonAuthenRoleFunctionPermission = new HashSet<CommonAuthenRoleFunctionPermission>();
        }

        public int Id { get; set; }
        public string FunctionName { get; set; }
        public string PermissionLevel { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CommonAuthenControllerActions> CommonAuthenControllerActions { get; set; }
        public virtual ICollection<CommonAuthenRoleFunctionPermission> CommonAuthenRoleFunctionPermission { get; set; }
    }
}
