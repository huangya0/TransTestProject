using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public bool? ChangePwdAtFirst { get; set; }
    }
}
