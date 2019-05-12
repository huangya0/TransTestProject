using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "登录名是必需的！")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "密码是必需的！")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
