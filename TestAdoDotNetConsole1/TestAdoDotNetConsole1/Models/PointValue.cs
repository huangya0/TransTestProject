using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class PointValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public float Value { get; set; }
        public int ValueType { get; set; }
        public int? RtSequence { get; set; }
    }
}
