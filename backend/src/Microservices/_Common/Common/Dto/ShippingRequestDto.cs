﻿using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class ShippingRequestDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CourierId { get; set; }
        public AddressDto AddressFrom { get; set; }
        public AddressDto AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public bool IsFinished { get; set; }
        public Status Status { get; set; }

        public PaymentOptionDto PaymentOption { get; set; }
        public ShippingOptionDto ShippingOption { get; set; }
        public BillingDto Billing { get; set; }

        public List<PackageDto> Packages { get; set; }
    }
}
