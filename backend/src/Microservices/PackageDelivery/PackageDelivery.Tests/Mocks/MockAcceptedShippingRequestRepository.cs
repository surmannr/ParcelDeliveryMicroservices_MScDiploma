namespace PackageDelivery.Tests.Mocks
{
    public static class MockAcceptedShippingRequestRepository
    {
        public static Mock<IAcceptedShippingRequestRepository> GetAcceptedShippingRequestRepository()
        {
            var mockRepo = new Mock<IAcceptedShippingRequestRepository>();

            mockRepo.Setup(r => r.GetAcceptedShippingRequests(It.IsAny<AcceptedShippingRequestFilter>())).ReturnsAsync(PagedData);
            mockRepo.Setup(r => r.GetAcceptedShippingRequestById(It.IsAny<string>())).ReturnsAsync((string id) =>
            {
                return AcceptedShippingRequests.First(x => x.Id == id);
            });
            mockRepo.Setup(r => r.GetAcceptedShippingRequestsByEmployeeId(It.IsAny<string>(), It.IsAny<AcceptedShippingRequestFilter>())).ReturnsAsync((string id, AcceptedShippingRequestFilter filter) => {
                return AcceptedShippingRequests.Where(x => x.EmployeeId == id).AsQueryable().ToPagedList(new PagingParameter());
            });
            
            mockRepo.Setup(r => r.CreateAcceptedShippingRequest(It.IsAny<AcceptedShippingRequest>())).ReturnsAsync((AcceptedShippingRequest entity) =>
            {
                AcceptedShippingRequests_Create.Add(entity);
                return entity.Id;
            });
            mockRepo.Setup(r => r.UpdateAcceptedShippingRequest(It.IsAny<AcceptedShippingRequest>())).ReturnsAsync((AcceptedShippingRequest entity) =>
            {
                var updElement = AcceptedShippingRequests_Update.Where(x => x.Id == entity.Id).FirstOrDefault();
                updElement = entity;
                return true;
            });
            mockRepo.Setup(r => r.DeleteAcceptedShippingRequest(It.IsAny<string>())).ReturnsAsync((string entity) =>
            {
                var delElement = AcceptedShippingRequests_Delete.Where(x => x.Id == entity).FirstOrDefault();
                AcceptedShippingRequests_Delete.Remove(delElement!);
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

        public static List<Package> Packages3Data { get; set; } = new List<Package>
        {
            new Package()
            {
                Id = "packID5",
                IsFragile= false,
                SizeX = 5,
                SizeY = 2,
                SizeZ = 7,
                Weight = 20,
                UserId = "test1",
                ShippingRequestId = "shipID3",
            },
        };

        public static List<ShippingRequest> ShippingRequestsData { get; set; } = new List<ShippingRequest>
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

        public static List<ShippingRequest> ShippingRequests2Data { get; set; } = new List<ShippingRequest>
            {
                new ShippingRequest()
                {
                    Id = "shipID3",
                    ShippingOptionId = 1,
                    ShippingOption = new ShippingOption() { Id = 1, Name = "Teherautó", Price = 5000},
                    Status = Status.Processing,
                    AddressFrom = new Address(),
                    AddressTo = new Address(),
                    BillingId = "billID3",
                    Billing = new Billing() { Id = "billID3"},
                    DateOfDispatch = DateTime.Now,
                    IsExpress = true,
                    IsFinished = false,
                    PaymentOptionId = 1,
                    PaymentOption = new PaymentOption() { Id = 1, Name = "Bankkártya"},
                    Name = "TestUser",
                    Packages = Packages1Data,
                    Email = "teszt@teszt.hu",
                },
            };

        public static List<AcceptedShippingRequest> AcceptedShippingRequests { get; set; } = new List<AcceptedShippingRequest>
            {
                new AcceptedShippingRequest
                {
                    Id = "teszt1",
                    EmployeeId = "tesztuserid",
                    EmployeeEmail = "teszt@teszt.hu",
                    EmployeeName = "Teszt Elek",
                    IsAssignedToEmployee = true,
                    IsAllPackageTaken = true,
                    ReadPackageIds = new[]
                    {
                        "packID1",
                        "packID2",
                        "packID3",
                        "packID4",
                    },
                    Vehicle = VehicleData,
                    ShippingRequests = ShippingRequestsData,
                    Packages = new List<Package>(Packages1Data!).Concat(Packages2Data!).ToList(),
                },
                new AcceptedShippingRequest
                {
                    Id = "teszt2",
                    EmployeeId = null,
                    EmployeeEmail = null,
                    EmployeeName = null,
                    IsAssignedToEmployee = false,
                    IsAllPackageTaken = false,
                    ReadPackageIds = new string[] {},
                    Vehicle = VehicleData,
                    ShippingRequests = ShippingRequests2Data,
                    Packages = new List<Package>(Packages3Data!),
                },
            };

        public static List<AcceptedShippingRequest> AcceptedShippingRequests_Create = new List<AcceptedShippingRequest>(AcceptedShippingRequests);
        public static List<AcceptedShippingRequest> AcceptedShippingRequests_Update = new List<AcceptedShippingRequest>(AcceptedShippingRequests);
        public static List<AcceptedShippingRequest> AcceptedShippingRequests_Delete = new List<AcceptedShippingRequest>(AcceptedShippingRequests);

        public static PagedResponse<AcceptedShippingRequest> PagedData { get; set; } = new PagedResponse<AcceptedShippingRequest>
        {
            Data = AcceptedShippingRequests,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = AcceptedShippingRequests!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<AcceptedShippingRequest> PagedData_Create { get; set; } = new PagedResponse<AcceptedShippingRequest>
        {
            Data = AcceptedShippingRequests_Create,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = AcceptedShippingRequests_Create!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<AcceptedShippingRequest> PagedData_Update { get; set; } = new PagedResponse<AcceptedShippingRequest>
        {
            Data = AcceptedShippingRequests_Update,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = AcceptedShippingRequests_Update!.Count,
            TotalPages = 1,
        };
        public static PagedResponse<AcceptedShippingRequest> PagedData_Delete { get; set; } = new PagedResponse<AcceptedShippingRequest>
        {
            Data = AcceptedShippingRequests_Delete,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = AcceptedShippingRequests_Delete!.Count,
            TotalPages = 1,
        };
    }
}
