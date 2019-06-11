using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class CubeEquipModelRel
    {
        public int Id { get; set; }
        public int EquipModelId { get; set; }
        public int CubeModelId { get; set; }
        public int EquipmentCount { get; set; }
    }
}
