﻿using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class EquipModelPtValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipModelId { get; set; }
        public int ValueType { get; set; }
        public int? RtSequence { get; set; }
    }
}
