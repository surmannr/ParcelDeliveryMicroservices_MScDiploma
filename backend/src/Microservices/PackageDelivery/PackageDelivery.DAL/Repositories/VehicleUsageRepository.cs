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
    public class VehicleUsageRepository : IVehicleUsageRepository
    {
        private readonly IPackageDeliveryContext _context;

        public VehicleUsageRepository(IPackageDeliveryContext context)
        {
            _context = context;
        }

        public async Task<VehicleUsage> GetVehicleUsageById(string id)
        {
            return await _context
                            .VehicleUsages
                            .Find(s => s.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedResponse<VehicleUsage>> GetVehicleUsageByEmployeeId(string employeeid, VehicleUsageFilter filter)
        {
            filter.EmployeeId = employeeid;
            return await _context
                            .VehicleUsages
                            .ExecuteFilterAndOrder(filter)
                            .ToPagedListAsync(filter);
        }

        public async Task<PagedResponse<VehicleUsage>> GetVehicleUsages(VehicleUsageFilter filter)
        {
            return await _context
                            .VehicleUsages
                            .ExecuteFilterAndOrder(filter)
                            .ToPagedListAsync(filter);
        }

        public async Task<string> CreateVehicleUsage(VehicleUsage vehicleUsage)
        {
            await _context.VehicleUsages.InsertOneAsync(vehicleUsage);

            return vehicleUsage.Id;
        }

        public async Task<bool> DeleteVehicleUsage(string id)
        {
            FilterDefinition<VehicleUsage> filter = Builders<VehicleUsage>.Filter.Eq(s => s.Id, id);

            var deleteResult = await _context
                .VehicleUsages
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateVehicleUsage(VehicleUsage vehicleUsage)
        {
            var updateResult = await _context
                .VehicleUsages
                .ReplaceOneAsync(filter: s => s.Id == vehicleUsage.Id, replacement: vehicleUsage);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
