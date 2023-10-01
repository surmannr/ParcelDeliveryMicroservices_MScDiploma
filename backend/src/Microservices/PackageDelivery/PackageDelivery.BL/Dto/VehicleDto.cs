using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace PackageDelivery.BL.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class VehicleDto
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public DateTime TechnicalInspectionExpirationDate { get; set; }
        public int SeatingCapacity { get; set; }
        public double MaxInternalSpaceX { get; set; }
        public double MaxInternalSpaceY { get; set; }
        public double MaxInternalSpaceZ { get; set; }
    }
}
