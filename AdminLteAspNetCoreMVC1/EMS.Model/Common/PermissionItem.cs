using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class PermissionItem
    {
        public PermissionItem()
        {
            RoleList = new List<int>();
        }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public bool HasActionPermission { get; set; }
        public List<int> RoleList { get; set; }
    }
}
