using Common.Paging;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.DAL.Repositories
{
    public interface IVehicleRepository
    {
        Task<PagedResponse<Vehicle>> GetVehicles(VehicleFilter filter);
        Task<Vehicle> GetVehicleById(string id);

        Task<string> CreateVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(string id);
    }
}
