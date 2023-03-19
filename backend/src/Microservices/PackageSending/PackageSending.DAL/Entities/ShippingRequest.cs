﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.DAL.Entities
{
    public class ShippingRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CourierId { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public int ShippingOptionId { get; set; }
        public int PaymentOptionId { get; set; }
        public string BillingId { get; set; }
        public bool IsFinished { get; set; }

        public PaymentOption PaymentOption { get; set; }
        public ShippingOption ShippingOption { get; set; }
        public Billing Billing { get; set; }
    }
}
