﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
    }
}
