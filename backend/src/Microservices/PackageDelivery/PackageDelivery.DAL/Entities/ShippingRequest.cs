using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Entities
{
    public class ShippingRequest
    {
        public string Id { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public string PaymentOption { get; set; }
        public string ShippingOption { get; set; }
        public Status Status { get; set; }
        public int Price { get; set; }
        public ICollection<Package> Packages { get; set; }
    }
}
