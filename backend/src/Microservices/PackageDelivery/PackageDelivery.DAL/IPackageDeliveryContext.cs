using MongoDB.Driver;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL
{
    public interface IPackageDeliveryContext
    {
        IMongoCollection<AcceptedShippingRequest> AcceptedShippingRequests { get; }
        IMongoCollection<VehicleUsage> VehicleUsages { get; }
        IMongoCollection<Vehicle> Vehicles { get; }
    }
}
