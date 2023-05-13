using Common.Dto;

namespace PackageDelivery.BL.Dto
{
    public class AcceptedShippingRequestDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public ShippingRequestDto Shipping { get; set; }
        public bool IsAllPackageTaken { get; set; }
        public string[] ReadPackageIds { get; set; }
    }
}
