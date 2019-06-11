using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class EquipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipmentType { get; set; }
        public string Abbreviation { get; set; }
        public int PortType { get; set; }
        public string ProtocolDllName { get; set; }
    }
}
