using Common.Paging;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public interface IVehicleUsageRepository
    {
        Task<PagedResponse<VehicleUsage>> GetVehicleUsages(VehicleUsageFilter filter);
        Task<VehicleUsage> GetVehicleUsageById(string id);
        Task<PagedResponse<VehicleUsage>> GetVehicleUsageByEmployeeId(string employeeid, VehicleUsageFilter filter);

        Task<string> CreateVehicleUsage(VehicleUsage vehicleUsage);
        Task<bool> UpdateVehicleUsage(VehicleUsage vehicleUsage);
        Task<bool> DeleteVehicleUsage(string id);
    }
}
