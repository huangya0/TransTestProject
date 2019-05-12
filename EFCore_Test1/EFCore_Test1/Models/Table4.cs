using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class Table4
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pid { get; set; }

        public virtual Table2 P { get; set; }
    }
}
