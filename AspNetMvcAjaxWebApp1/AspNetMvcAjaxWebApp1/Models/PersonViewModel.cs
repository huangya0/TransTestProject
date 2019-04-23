using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcAjaxWebApp1.Models
{
    public enum CityEnum
    {
        BJ = 0,
        SZ,
        SH,
        GZ
    }

    public class SubmitViewModel
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }


    [Bind(Exclude = "PersonID")]
    public class PersonViewModel
    {
        [ScaffoldColumn(false)]
        public int PersonID { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "不能为空")]
        public string Name { get; set; }

        [Display(Name = "手机号")]
        [Required(ErrorMessage = "不能为空")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }

        public bool IsMarried { get; set; }

        public string Email { get; set; }
        public CityEnum Home { get; set; }
        public int Height { get; set; }
    }
}