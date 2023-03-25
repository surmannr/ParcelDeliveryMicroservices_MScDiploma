using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public interface IVehicleUsageRepository
    {
        Task<IEnumerable<VehicleUsage>> GetVehicleUsages();
        Task<VehicleUsage> GetVehicleUsageById(string id);
        Task<IEnumerable<VehicleUsage>> GetVehicleUsageByEmployeeId(string employeeid);

        Task<string> CreateVehicleUsage(VehicleUsage vehicleUsage);
        Task<bool> UpdateVehicleUsage(VehicleUsage vehicleUsage);
        Task<bool> DeleteVehicleUsage(string id);
    }
}
