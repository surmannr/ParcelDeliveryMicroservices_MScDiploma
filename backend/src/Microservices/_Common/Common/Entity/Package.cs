﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Package
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }
        public double Weight { get; set; }
        public bool IsFragile { get; set; }

        public string ShippingRequestId { get; set; }
        public ShippingRequest ShippingRequest { get; set; }
    }
}
