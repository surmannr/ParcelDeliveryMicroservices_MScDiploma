using Common.Dto;
using Common.Entity;
using PackageDelivery.DAL.Entities;
using TypeGen.Core.TypeAnnotations;

namespace PackageDelivery.BL.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class AcceptedShippingRequestDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public VehicleDto Vehicle { get; set; }
        public List<PackageDto> Packages { get; set; } // Ez külön tárolva, mert nem biztos hogy egy autóban elférnek a megrendelt csomagok, lehet két autóval fogják vinni pl.
        public List<ShippingRequestDto> ShippingRequests { get; set; } // Ha itt szerepel egy ShippingRequest, attól még szerepelhet más AcceptedShippingRequestbe
        public bool IsAllPackageTaken { get; set; }
        public bool IsAssignedToEmployee { get; set; }
        public string[] ReadPackageIds { get; set; }
    }
}
