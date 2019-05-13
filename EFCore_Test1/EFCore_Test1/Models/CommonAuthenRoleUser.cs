using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenRoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual CommonAuthenRole Role { get; set; }
        public virtual CommonAuthenUser User { get; set; }
    }
}
