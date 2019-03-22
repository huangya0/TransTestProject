namespace EF_FromDBCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_4
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        [StringLength(10)]
        public string pid { get; set; }

        public virtual Table_2 Table_2 { get; set; }
    }
}
