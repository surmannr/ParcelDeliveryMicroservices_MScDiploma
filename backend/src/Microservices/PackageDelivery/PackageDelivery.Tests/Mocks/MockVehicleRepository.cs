using Common.Entity.Filters;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.Mocks
{
    public class MockVehicleRepository
    {
        public static Mock<IVehicleRepository> GetVehicleRepository()
        {
            var mockRepo = new Mock<IVehicleRepository>();

            mockRepo.Setup(r => r.GetVehicles(It.IsAny<VehicleFilter>())).ReturnsAsync(PagedData);
            mockRepo.Setup(r => r.GetVehicleById(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                return Vehicles.First(x => x.Id == id);
            });

            mockRepo.Setup(r => r.CreateVehicle(It.IsAny<Vehicle>())).ReturnsAsync((Vehicle entity) =>
            {
                Vehicles_Create.Add(entity);
                return entity.Id;
            });
            mockRepo.Setup(r => r.UpdateVehicle(It.IsAny<Vehicle>())).ReturnsAsync((Vehicle entity) =>
            {
                var updElement = Vehicles_Update.Where(x => x.Id == entity.Id).FirstOrDefault();
                updElement = entity;
                return true;
            });
            mockRepo.Setup(r => r.DeleteVehicle(It.IsAny<string>())).ReturnsAsync((string entity) =>
            {
                var delElement = Vehicles_Delete.Where(x => x.Id == entity).FirstOrDefault();
                Vehicles_Delete.Remove(delElement!);
                return true;
            });

            return mockRepo;
        }

        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>
        {
            new Vehicle()
            {
                Id = "vehicleID1",
                SeatingCapacity = 4,
                MaxInternalSpaceX = 4,
                MaxInternalSpaceY = 3,
                MaxInternalSpaceZ = 5,
                MaxWeight = 10,
                RegistrationNumber = "TST-123",
                TechnicalInspectionExpirationDate = DateTime.Now,
                Type = "TesztType",
                Year = 2023,
            },
            new Vehicle()
            {
                Id = "vehicleID2",
                SeatingCapacity = 1,
                MaxInternalSpaceX = 1,
                MaxInternalSpaceY = 1,
                MaxInternalSpaceZ = 1,
                MaxWeight = 20,
                RegistrationNumber = "ABC-555",
                TechnicalInspectionExpirationDate = DateTime.Now,
                Type = "TesztType",
                Year = 2022,
            }
        };

        public static List<Vehicle> Vehicles_Create = new List<Vehicle>(Vehicles);
        public static List<Vehicle> Vehicles_Update = new List<Vehicle>(Vehicles);
        public static List<Vehicle> Vehicles_Delete = new List<Vehicle>(Vehicles);

        public static PagedResponse<Vehicle> PagedData { get; set; } = new PagedResponse<Vehicle>
        {
            Data = Vehicles,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = Vehicles!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<Vehicle> PagedData_Create { get; set; } = new PagedResponse<Vehicle>
        {
            Data = Vehicles_Create,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = Vehicles_Create!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<Vehicle> PagedData_Update { get; set; } = new PagedResponse<Vehicle>
        {
            Data = Vehicles_Update,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = Vehicles_Update!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<Vehicle> PagedData_Delete { get; set; } = new PagedResponse<Vehicle>
        {
            Data = Vehicles_Delete,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = Vehicles_Delete!.Count,
            TotalPages = 1,
        };
    }
}
