namespace EF_FromDBCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
