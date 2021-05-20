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

        /*public Routes(int id, TransportType _type, TransportCenter centerA, TransportCenter centerB,
            int travelTime = Int32.MaxValue)
        {
            Id = id;
            Type = _type;
            CenterA = centerA;
            CenterB = centerB;
            TravelTime = travelTime;

        }*/

    }
}