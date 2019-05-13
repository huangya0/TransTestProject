using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenRoleFunctionPermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionLevelId { get; set; }
        public string Description { get; set; }

        public virtual CommonAuthenFunctionPermissionLevel PermissionLevel { get; set; }
        public virtual CommonAuthenRole Role { get; set; }
    }
}
