﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class ShippingRequest
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CourierId { get; set; }
        [BsonIgnoreIfNull]
        public Address AddressFrom { get; set; }
        [BsonIgnoreIfNull]
        public Address AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DateOfDispatch { get; set; }
        public Status Status { get; set; }

        public int PaymentOptionId { get; set; }
        public PaymentOption PaymentOption { get; set; }

        public int ShippingOptionId { get; set; }
        public ShippingOption ShippingOption { get; set; }

        public string BillingId { get; set; }
        [BsonIgnoreIfNull]
        public Billing Billing { get; set; }

        public List<Package> Packages { get; set; }
    }
}
