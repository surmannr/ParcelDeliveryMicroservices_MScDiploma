using Common.Filter;
using Common.Paging;
using MongoDB.Driver;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IPackageDeliveryContext _context;

        public VehicleRepository(IPackageDeliveryContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicleById(string id)
        {
            return await _context
                            .Vehicles
                            .Find(s => s.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedResponse<Vehicle>> GetVehicles(VehicleFilter filter)
        {
            return await _context
                            .Vehicles
                            .ExecuteFilterAndOrder(filter)
                            .ToPagedListAsync(filter);
        }

        public async Task<string> CreateVehicle(Vehicle vehicle)
        {
            await _context.Vehicles.InsertOneAsync(vehicle);

            return vehicle.Id;
        }

        public async Task<bool> DeleteVehicle(string id)
        {
            FilterDefinition<Vehicle> filter = Builders<Vehicle>.Filter.Eq(s => s.Id, id);

            var deleteResult = await _context
                .Vehicles
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            var updateResult = await _context
                .Vehicles
                .ReplaceOneAsync(filter: s => s.Id == vehicle.Id, replacement: vehicle);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
