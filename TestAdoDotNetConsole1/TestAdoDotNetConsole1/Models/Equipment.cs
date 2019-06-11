using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipmentType { get; set; }
        public int? PccId { get; set; }
        public int? CubeId { get; set; }
    }
}
