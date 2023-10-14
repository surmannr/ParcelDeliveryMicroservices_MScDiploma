using Moq;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.Mocks
{
    public class MockVehicleUsageRepository
    {
        public static Mock<IVehicleUsageRepository> GetAcceptedShippingRequestRepository()
        {
            var mockRepo = new Mock<IVehicleUsageRepository>();

            mockRepo.Setup(r => r.GetVehicleUsages(It.IsAny<VehicleUsageFilter>())).ReturnsAsync(PagedData);
            mockRepo.Setup(r => r.GetVehicleUsageById(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                return VehicleUsages.First(x => x.Id == id);
            });
            mockRepo.Setup(r => r.GetVehicleUsageByEmployeeId(It.IsAny<string>(), It.IsAny<VehicleUsageFilter>())).ReturnsAsync((string id, AcceptedShippingRequestFilter filter) => {
                return VehicleUsages.Where(x => x.EmployeeId == id).AsQueryable().ToPagedList(new PagingParameter());
            });

            mockRepo.Setup(r => r.CreateVehicleUsage(It.IsAny<VehicleUsage>())).ReturnsAsync((VehicleUsage entity) =>
            {
                entity.Id = "teszt1";
                VehicleUsages_Create.Add(entity);
                return entity.Id;
            });
            mockRepo.Setup(r => r.UpdateVehicleUsage(It.IsAny<VehicleUsage>())).ReturnsAsync((VehicleUsage entity) =>
            {
                var updElement = VehicleUsages_Update.Where(x => x.Id == entity.Id).FirstOrDefault();
                updElement = entity;
                return true;
            });
            mockRepo.Setup(r => r.DeleteVehicleUsage(It.IsAny<string>())).ReturnsAsync((string entity) =>
            {
                var delElement = VehicleUsages_Delete.Where(x => x.Id == entity).FirstOrDefault();
                VehicleUsages_Delete.Remove(delElement!);
                return true;
            });

            return mockRepo;
        }


        public static List<VehicleUsage> VehicleUsages { get; set; } = new List<VehicleUsage>
            {
                new VehicleUsage
                {
                    Id = "teszt1",
                    EmployeeId = "tesztuserid",
                    EmployeeEmail = "teszt@teszt.hu",
                    EmployeeName = "Teszt Elek",
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(7),
                    Vehicle = new Vehicle()
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
                },
                new VehicleUsage
                {
                    Id = "teszt2",
                    EmployeeId = "tesztuserid2",
                    EmployeeEmail = "teszt2@teszt.hu",
                    EmployeeName = "Teszt2 Elek",
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now.AddDays(7),
                    Vehicle = new Vehicle()
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
                    },
                },
        };

        public static List<VehicleUsage> VehicleUsages_Create = new List<VehicleUsage>(VehicleUsages);
        public static List<VehicleUsage> VehicleUsages_Update = new List<VehicleUsage>(VehicleUsages);
        public static List<VehicleUsage> VehicleUsages_Delete = new List<VehicleUsage>(VehicleUsages);

        public static PagedResponse<VehicleUsage> PagedData { get; set; } = new PagedResponse<VehicleUsage>
        {
            Data = VehicleUsages,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = VehicleUsages!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<VehicleUsage> PagedData_Create { get; set; } = new PagedResponse<VehicleUsage>
        {
            Data = VehicleUsages_Create,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = VehicleUsages_Create!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<VehicleUsage> PagedData_Update { get; set; } = new PagedResponse<VehicleUsage>
        {
            Data = VehicleUsages_Update,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = VehicleUsages_Update!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<VehicleUsage> PagedData_Delete { get; set; } = new PagedResponse<VehicleUsage>
        {
            Data = VehicleUsages_Delete,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = VehicleUsages_Delete!.Count,
            TotalPages = 1,
        };
    }
}
