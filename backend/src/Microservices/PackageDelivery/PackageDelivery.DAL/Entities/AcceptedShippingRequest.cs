using Common.Entity;
using MongoDB.Bson.Serialization.Attributes;

namespace PackageDelivery.DAL.Entities
{
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
        public string[] ReadPackageIds { get; set; }
    }
}
