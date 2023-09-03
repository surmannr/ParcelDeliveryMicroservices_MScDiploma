using Common.Serializers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PackageDelivery.DAL.Entities
{
    public class Vehicle
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public DateTime TechnicalInspectionExpirationDate { get; set; }
        public int SeatingCapacity { get; set; }
        public double MaxInternalSpaceX { get; set; }
        public double MaxInternalSpaceY { get; set; }
        public double MaxInternalSpaceZ { get; set; }
        public double MaxWeight { get; set; }
    }
}
