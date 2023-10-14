using Common.Entity.Filters;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.Mocks
{
    public static class MockShippingRequestRepository
    {
        public static Mock<IShippingRequestRepository> GetShippingRequestRepository()
        {
            var mockRepo = new Mock<IShippingRequestRepository>();

            mockRepo.Setup(r => r.GetShippingRequests(It.IsAny<ShippingRequestMongoFilter>())).ReturnsAsync(PagedData);
            mockRepo.Setup(r => r.GetShippingRequestById(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                return ShippingRequests.First(x => x.Id == id);
            });

            mockRepo.Setup(r => r.CreateShippingRequest(It.IsAny<ShippingRequest>())).ReturnsAsync((ShippingRequest entity) =>
            {
                ShippingRequests_Create.Add(entity);
                return entity.Id;
            });
            mockRepo.Setup(r => r.UpdateShippingRequest(It.IsAny<ShippingRequest>())).ReturnsAsync((ShippingRequest entity) =>
            {
                var updElement = ShippingRequests_Update.Where(x => x.Id == entity.Id).FirstOrDefault();
                updElement = entity;
                return true;
            });
            mockRepo.Setup(r => r.DeleteShippingRequest(It.IsAny<string>())).ReturnsAsync((string entity) =>
            {
                var delElement = ShippingRequests_Delete.Where(x => x.Id == entity).FirstOrDefault();
                ShippingRequests_Delete.Remove(delElement!);
                return true;
            });

            return mockRepo;
        }

        public static Vehicle VehicleData { get; } = new Vehicle()
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
        };

        public static List<Package> Packages1Data { get; set; } = new List<Package>
        {
            new Package()
            {
                Id = "packID1",
                IsFragile= true,
                SizeX = 1,
                SizeY = 1,
                SizeZ = 1,
                Weight = 2,
                UserId = "test1",
                ShippingRequestId = "shipID1",
            },
            new Package()
            {
                Id = "packID2",
                IsFragile= false,
                SizeX = 2,
                SizeY = 2,
                SizeZ = 2,
                Weight = 3,
                UserId = "test1",
                ShippingRequestId = "shipID1",
            }
        };

        public static List<Package> Packages2Data { get; set; } = new List<Package>
        {
            new Package()
            {
                Id = "packID3",
                IsFragile= true,
                SizeX = 3,
                SizeY = 3,
                SizeZ = 3,
                Weight = 4,
                UserId = "test2",
                ShippingRequestId = "shipID2",
            },
            new Package()
            {
                Id = "packID4",
                IsFragile= false,
                SizeX = 4,
                SizeY = 4,
                SizeZ = 5,
                Weight = 6,
                UserId = "test2",
                ShippingRequestId = "shipID2",
            }
        };


        public static List<ShippingRequest> ShippingRequests { get; set; } = new List<ShippingRequest>
            {
                new ShippingRequest()
                {
                    Id = "shipID1",
                    ShippingOptionId = 1,
                    ShippingOption = new ShippingOption() { Id = 1, Name = "Teherautó", Price = 5000},
                    Status = Status.Packing,
                    AddressFrom = new Address(),
                    AddressTo = new Address(),
                    BillingId = "billID1",
                    Billing = new Billing() { Id = "billID1"},
                    DateOfDispatch = DateTime.Now,
                    IsExpress = false,
                    IsFinished = false,
                    PaymentOptionId = 1,
                    PaymentOption = new PaymentOption() { Id = 1, Name = "Bankkártya"},
                    Name = "TestUser",
                    Packages = Packages1Data,
                    Email = "teszt@teszt.hu",
                },
                new ShippingRequest()
                {
                    Id = "shipID2",
                    ShippingOptionId = 2,
                    ShippingOption = new ShippingOption() { Id = 2, Name = "Átvétel helyben", Price = 0},
                    Status = Status.Delivered,
                    AddressFrom = new Address(),
                    AddressTo = new Address(),
                    BillingId = "billID2",
                    Billing = new Billing() { Id = "billID2"},
                    DateOfDispatch = DateTime.Now,
                    IsExpress = true,
                    IsFinished = true,
                    PaymentOptionId = 2,
                    PaymentOption = new PaymentOption() { Id = 2, Name = "Készpénz"},
                    Name = "TestUser2",
                    Packages = Packages2Data,
                    Email = "teszt2@teszt.hu",
                }
            };

        public static List<ShippingRequest> ShippingRequests_Create = new List<ShippingRequest>(ShippingRequests);
        public static List<ShippingRequest> ShippingRequests_Update = new List<ShippingRequest>(ShippingRequests);
        public static List<ShippingRequest> ShippingRequests_Delete = new List<ShippingRequest>(ShippingRequests);

        public static PagedResponse<ShippingRequest> PagedData { get; set; } = new PagedResponse<ShippingRequest>
        {
            Data = ShippingRequests,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = ShippingRequests!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<ShippingRequest> PagedData_Create { get; set; } = new PagedResponse<ShippingRequest>
        {
            Data = ShippingRequests_Create,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = ShippingRequests_Create!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<ShippingRequest> PagedData_Update { get; set; } = new PagedResponse<ShippingRequest>
        {
            Data = ShippingRequests_Update,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = ShippingRequests_Update!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<ShippingRequest> PagedData_Delete { get; set; } = new PagedResponse<ShippingRequest>
        {
            Data = ShippingRequests_Delete,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = ShippingRequests_Delete!.Count,
            TotalPages = 1,
        };
    }
}
