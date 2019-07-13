using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class EquipmentChannel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public int PortType { get; set; }
        public string ProtocolName { get; set; }
        public string PortParameters { get; set; }
        public string ProtocolParam { get; set; }
        public bool IsConnect { get; set; }
    }
}
