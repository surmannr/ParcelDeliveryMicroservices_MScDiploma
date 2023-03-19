using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Dto
{
    public class AcceptedShippingRequestDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public ShippingRequestDto Shipping { get; set; }
        public bool IsAllPackageTaken { get; set; }
        public string[] ReadPackageIds { get; set; }
    }
}
