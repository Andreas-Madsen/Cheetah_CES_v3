using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Models
{
    public class Routes
    {
        public int Id { get; set; }

        public TransportType Type { get; set; }

        public TransportCenter CenterA { get; set; }

        public TransportCenter CenterB { get; set; }

        public int TravelTime { get; set; }
    }
}