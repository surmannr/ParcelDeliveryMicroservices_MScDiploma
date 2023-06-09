﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Entities
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
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
