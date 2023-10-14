using Common.Dto;
using PackageTracking.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageTracking.Tests.UnitTests
{
    public class ShippingRequestUnitTests : UnitTestBase
    {
        private readonly IPackageTrackingRepository repo;
        public ShippingRequestUnitTests() : base()
        {
            repo = new MockTrackingRepository(ShippingRequests);
        }

        private ShippingRequestDto element = new ShippingRequestDto()
        {
            Id = "sid3",
            Status = Status.Delivered,
            AddressFrom = new AddressDto(),
            AddressTo = new AddressDto(),
            IsExpress = false,
            IsFinished = false,
            Name = "Teszt3 Elek",
            Packages = new List<PackageDto>(),
            Email = "teszt3@teszt.hu",
            CourierId = "asd",
        };

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = "sid1";
            var firstElement = ShippingRequests.First();

            // Act
            var result = await repo.GetShipping(id);

            // Assert
            result.ShouldBeOfType<ShippingRequestDto>();
            result.Name.ShouldBe(firstElement.Name);
            result.IsExpress.ShouldBe(firstElement.IsExpress);
            result.IsFinished.ShouldBe(firstElement.IsFinished);
            result.AddressTo.City.ShouldBe(firstElement.AddressTo.City);
            result.Status.ShouldBe(firstElement.Status);
            result.PaymentOption.Name.ShouldBe(firstElement.PaymentOption.Name);
            result.ShippingOption.Name.ShouldBe(firstElement.ShippingOption.Name);
            result.UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Name = "asd";

            // Act
            var result = await repo.UpdateShipping(element);

            // Assert
            result.ShouldBeOfType<ShippingRequestDto>();

            var elements = ShippingRequests;
            elements.Count.ShouldBe(3);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().Name.ShouldBe("asd");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var id = "sid1";

            // Act
            await repo.DeleteShipping(id);

            // Assert
            var elements = ShippingRequests;
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }

        public List<ShippingRequestDto> ShippingRequests { get; set; } = new List<ShippingRequestDto>
            {
                new ShippingRequestDto()
                {
                    Id = "sid1",
                    ShippingOption = new ShippingOptionDto() { Id = 1, Name = "Teherautó", Price = 5000},
                    Status = Status.Packing,
                    AddressFrom = new AddressDto(),
                    AddressTo = new AddressDto(),
                    Billing = new BillingDto() { Id = "billID1"},
                    IsExpress = false,
                    IsFinished = false,
                    PaymentOption = new PaymentOptionDto() { Id = 1, Name = "Bankkártya"},
                    Name = "TestUser",
                    Packages = new List<PackageDto>
                    {
                        new PackageDto()
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
                        new PackageDto()
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
                    },
                    Email = "teszt@teszt.hu",
                },
                new ShippingRequestDto()
                {
                    Id = "sid2",
                    ShippingOption = new ShippingOptionDto() { Id = 2, Name = "Átvétel helyben", Price = 0},
                    Status = Status.Delivered,
                    AddressFrom = new AddressDto(),
                    AddressTo = new AddressDto(),
                    Billing = new BillingDto() { Id = "billID2"},
                    IsExpress = true,
                    IsFinished = true,
                    PaymentOption = new PaymentOptionDto() { Id = 2, Name = "Készpénz"},
                    Name = "TestUser2",
                    Packages = new List<PackageDto>
                    {
                        new PackageDto()
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
                        new PackageDto()
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
                    },
                    Email = "teszt2@teszt.hu",
                }
            };
    }
}
