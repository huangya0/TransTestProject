using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class Table2
    {
        public Table2()
        {
            Table4 = new HashSet<Table4>();
        }

        public string Id { get; set; }
        public string Name1 { get; set; }

        public virtual ICollection<Table4> Table4 { get; set; }
    }
}
