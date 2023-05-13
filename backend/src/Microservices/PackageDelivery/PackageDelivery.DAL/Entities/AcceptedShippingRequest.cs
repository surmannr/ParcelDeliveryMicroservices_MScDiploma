using Common.Entity;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Entities
{
    public class AcceptedShippingRequest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public ShippingRequest Shipping { get; set; }
        public bool IsAllPackageTaken { get; set; }
        public string[] ReadPackageIds { get; set; }
    }
}
