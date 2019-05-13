using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class SampleItemModel : BaseModel
    {
        public SampleItemModel()
        {
            //
        }

        public int Id { get; set; }

        //[Required(ErrorMessageResourceName = "Name_Required_Msg", ErrorMessageResourceType = typeof(MessageResource))]
        //[StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "Name_Length_Msg", ErrorMessageResourceType = typeof(MessageResource))]
        public string Name { get; set; }

        public string Address { get; set; }

    }
}
