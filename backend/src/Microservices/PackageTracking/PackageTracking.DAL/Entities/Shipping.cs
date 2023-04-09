using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.DAL.Entities
{
    public class Shipping
    {
        public string Id { get; set; }
        public Sender SenderInformation { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
        public string PaymentOptionName { get; set; }
        public string ShippingOptionName { get; set; }
        public string Status { get; set; }
        public double ShippingOptionPrice { get; set; }
        public bool IsExpress { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<Package> Packages { get; set; }
    }
}
