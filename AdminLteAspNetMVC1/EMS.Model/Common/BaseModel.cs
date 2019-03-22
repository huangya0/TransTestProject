using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class BaseModel
    {
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? UpdatedByID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int? CreatedByID { get; set; }
    }
}
