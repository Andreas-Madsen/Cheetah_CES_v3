using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Models
{
    public class Package
    {
        public int ID { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public double Weight { get; set; }

        public int RecordedPackage { get; set; }

        public int LiveAnimals { get; set; }

        public int CautiousParcel { get; set; }

        public int RefregiatedGoods { get; set; }

    }
}