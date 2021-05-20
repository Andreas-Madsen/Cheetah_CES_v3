using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Cheetah_Transport.Models
{
    public class TransportType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double PricePerHour { get; set; }
    }
}