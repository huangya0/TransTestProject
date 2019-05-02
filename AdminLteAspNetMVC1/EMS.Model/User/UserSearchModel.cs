using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.User
{
    public class UserSearchModel : BaseSearchModel
    {
        public string LogonName { get; set; }
        public string FullName { get; set; }
    }
}
