using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL
{
    public class PackageDeliveryContext : IPackageDeliveryContext
    {
        public PackageDeliveryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            AcceptedShippingRequests = database.GetCollection<AcceptedShippingRequest>(configuration["DatabaseSettings:CollectionName:AcceptedShippingRequest"]);
            VehicleUsages = database.GetCollection<VehicleUsage>(configuration["DatabaseSettings:CollectionName:VehicleUsage"]);
            Vehicles = database.GetCollection<Vehicle>(configuration["DatabaseSettings:CollectionName:Vehicle"]);
        }

        public IMongoCollection<AcceptedShippingRequest> AcceptedShippingRequests { get; }

        public IMongoCollection<VehicleUsage> VehicleUsages { get; }

        public IMongoCollection<Vehicle> Vehicles { get; }
    }
}
