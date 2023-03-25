using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Dto
{
    public class NewVehicleUsageDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string VehicleId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
    }
}
