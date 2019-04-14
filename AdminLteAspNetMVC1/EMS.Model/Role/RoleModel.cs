using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Role
{
    public class RoleModel
    {
        public List<RoleItemModel> ItemList { get; set; }
        public RoleSearchModel Search { get; set; }
    }
}
