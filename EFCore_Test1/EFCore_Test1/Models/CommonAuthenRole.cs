using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenRole
    {
        public CommonAuthenRole()
        {
            CommonAuthenRoleFunctionPermission = new HashSet<CommonAuthenRoleFunctionPermission>();
            CommonAuthenRoleUser = new HashSet<CommonAuthenRoleUser>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool? ShowFlag { get; set; }
        public string ResourceKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CommonAuthenRoleFunctionPermission> CommonAuthenRoleFunctionPermission { get; set; }
        public virtual ICollection<CommonAuthenRoleUser> CommonAuthenRoleUser { get; set; }
    }
}
