namespace EMS.DataProvider.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Table_5
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(10)]
        public string name { get; set; }
    }
}
