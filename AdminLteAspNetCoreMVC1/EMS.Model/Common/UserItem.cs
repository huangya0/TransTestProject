using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class UserItem
    {
        public UserItem()
        {
            this.RoleList = new List<int>();
        }

        public int ID { get; set; }
        public string LogonName { get; set; }
        public string FullName { get; set; }
        public List<int> RoleList { get; set; }
        
    }
}
