using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Role
{
    public class RoleItemModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessageResourceName = "RoleItem_RoleName", ErrorMessageResourceType = typeof(MessageResource))]
        [Required(ErrorMessage = "RoleName必填")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool ShowFlag { get; set; }
    }
}
