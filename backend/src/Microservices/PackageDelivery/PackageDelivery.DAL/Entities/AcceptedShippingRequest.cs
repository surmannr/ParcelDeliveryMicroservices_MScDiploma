using Common.Entity;
using MongoDB.Bson.Serialization.Attributes;
using TypeGen.Core.TypeAnnotations;

namespace PackageDelivery.DAL.Entities
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_models")]
    public class AcceptedShippingRequest
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<Package> Packages { get; set; }
        public List<ShippingRequest> ShippingRequests { get; set; }
        public bool IsAllPackageTaken { get; set; }
        public bool IsAssignedToEmployee { get; set; }
        public string[] ReadPackageIds { get; set; }
    }
}
