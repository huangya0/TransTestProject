using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class UserRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RightType { get; set; }
    }
}
