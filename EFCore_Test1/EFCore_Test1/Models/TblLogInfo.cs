using System;
using System.Collections.Generic;

namespace EFCore_Test1.Models
{
    public partial class TblLogInfo
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string Thread { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
