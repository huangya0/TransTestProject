using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLteAspNetMVC1.Models
{
    public class Users
    {

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public DateTime Birthday { get; set; }

    }
}