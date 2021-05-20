using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Models
{
    public class ExtraCost
    {
        public int ID { get; set; }
        
        public string Type { get; set; }

        public double Fee { get; set; }

        public int PackageID { get; set; }
    }
}