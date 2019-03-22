using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProvider.Models
{
    public partial class tbl_LogInfo
    {
        public int ID { get; set; }

        public DateTime LogTime { get; set; }

        [Required]
        public string Thread { get; set; }

        public string LogLevel { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
    }
}
