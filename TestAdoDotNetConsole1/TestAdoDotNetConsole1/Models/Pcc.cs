using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class Pcc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StationId { get; set; }
    }
}
