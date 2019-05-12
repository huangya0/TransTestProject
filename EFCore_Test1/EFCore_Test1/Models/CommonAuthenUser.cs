using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class CommonAuthenUser
    {
        public CommonAuthenUser()
        {
            CommonAuthenRoleUser = new HashSet<CommonAuthenRoleUser>();
        }

        public int UserId { get; set; }
        public string LogonName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Idnumber { get; set; }
        public DateTime? DateOfbirth { get; set; }
        public int Status { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CommonAuthenRoleUser> CommonAuthenRoleUser { get; set; }
    }
}
