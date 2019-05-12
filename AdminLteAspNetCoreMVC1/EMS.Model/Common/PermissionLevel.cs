using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.Common
{
    public class PermissionLevel
    {
        public int ID { get; set; }
        public string FunctionName { get; set; }
        public string LevelName { get; set; }
        public bool Available { get; set; }
    }
}
