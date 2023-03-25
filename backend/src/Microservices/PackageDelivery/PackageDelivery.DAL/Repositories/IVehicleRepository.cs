using PackageDelivery.DAL.Entities;

namespace PackageDelivery.DAL.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicleById(string id);

        Task<string> CreateVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(string id);
    }
}
