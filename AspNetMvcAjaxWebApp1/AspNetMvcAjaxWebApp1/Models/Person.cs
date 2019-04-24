using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcAjaxWebApp1.Models
{
    public class Person
    {
        public string FirstName { get;set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }
    }
}