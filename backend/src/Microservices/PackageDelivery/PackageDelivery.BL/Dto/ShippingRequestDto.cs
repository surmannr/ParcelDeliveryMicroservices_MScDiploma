using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Dto
{
    public class ShippingRequestDto
    {
        public string Id { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public string PaymentOption { get; set; }
        public string ShippingOption { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public ICollection<PackageDto> Packages { get; set; }
    }
}
