using System;
using System.Collections.Generic;

namespace TestAdoDotNetConsole1.Models
{
    public partial class ClientRegHistory
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime QuiteTime { get; set; }
        public int QuiteType { get; set; }
        public string QuiteDesc { get; set; }
    }
}
