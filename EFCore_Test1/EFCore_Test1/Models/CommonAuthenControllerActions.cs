using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenControllerActions
    {
        public int Id { get; set; }
        public int PermissionLevelId { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public bool HasActionPermission { get; set; }
        public string Description { get; set; }

        public virtual CommonAuthenFunctionPermissionLevel PermissionLevel { get; set; }
    }
}
