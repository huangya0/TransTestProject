using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.User
{
    public class UserModel
    {
        //public UserModel()
        //{
        //    Search = new UserSearchModel() { LogonName = "test"};
        //}

        public List<VmTblUser> ItemList { get; set; }
        public UserSearchModel Search { get; set; }
    }
}
