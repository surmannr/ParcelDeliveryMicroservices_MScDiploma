using Common.Dto;
using MassTransit;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._ShipRequest.Commands;
using PackageSending.BL.Features._ShipRequest.Queries;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests.UnitTests
{
    public class ShippingRequestUnitTests : UnitTestBase
    {
        public ShippingRequestUnitTests() : base() { }

        private ShippingRequest element = new ShippingRequest()
        {
            Id = "sid3",
            ShippingOptionId = 1,
            Status = Status.Delivered,
            AddressFrom = new Address(),
            AddressTo = new Address(),
            BillingId = "bid1",
            DateOfDispatch = DateTime.Now,
            IsExpress = false,
            IsFinished = false,
            PaymentOptionId = 1,
            Name = "Teszt3 Elek",
            Packages = new List<Package>() { SeedData.Package2, SeedData.Package3 },
            Email = "teszt3@teszt.hu",
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllShipRequests.Query();
            var handler = new GetAllShipRequests.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.ShippingRequest1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<ShippingRequestDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<ShippingRequestDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().IsExpress.ShouldBe(firstElement.IsExpress);
            result.Data.First().IsFinished.ShouldBe(firstElement.IsFinished);
            result.Data.First().AddressTo.City.ShouldBe(firstElement.AddressTo.City);
            result.Data.First().Status.ShouldBe(firstElement.Status);
            result.Data.First().PaymentOption.Name.ShouldBe(firstElement.PaymentOption.Name);
            result.Data.First().ShippingOption.Name.ShouldBe(firstElement.ShippingOption.Name);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task GetAllByUserId()
        {
            // Arrange
            var userId = "teszt1";
            var query = new GetAllShipRequestsByUserId.Query() { UserId = userId };
            var handler = new GetAllShipRequestsByUserId.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.ShippingRequest1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<ShippingRequestDto>>();
            result.TotalCount.ShouldBe(1);
            result.Data.Count.ShouldBe(1);

            result.Data.First().ShouldBeOfType<ShippingRequestDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().IsExpress.ShouldBe(firstElement.IsExpress);
            result.Data.First().IsFinished.ShouldBe(firstElement.IsFinished);
            result.Data.First().AddressTo.City.ShouldBe(firstElement.AddressTo.City);
            result.Data.First().Status.ShouldBe(firstElement.Status);
            result.Data.First().PaymentOption.Name.ShouldBe(firstElement.PaymentOption.Name);
            result.Data.First().ShippingOption.Name.ShouldBe(firstElement.ShippingOption.Name);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = "sid1";
            var query = new GetShipRequestById.Query() { Id = id };
            var handler = new GetShipRequestById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.ShippingRequest1;

            // Act
            var result = await handler.Handle(query, default);

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
        public async Task Create()
        {
            // Arrange
            Mock<IPublishEndpoint> mockedEndpoint = new Mock<IPublishEndpoint>();
            var query = new AddNewShipRequest.Command() { NewShipRequest = _mapper.Map<NewShippingRequestDto>(element) };
            var handler = new AddNewShipRequest.Handler(_mapper, _dbContext.Object, mockedEndpoint.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();

            var elements = _dbContext.Object.ShippingRequests.ToList();
            elements.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = "sid1";
            element.CourierId = "asd";
            var query = new EditShipRequest.Command() { ModifiedShipping = _mapper.Map<NewShippingRequestDto>(element), Id = element.Id };
            var handler = new EditShipRequest.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.ShippingRequests.ToList();
            elements.Count.ShouldBe(2);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().CourierId.ShouldBe("asd");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteShipRequest.Command() { Id = "sid1" };
            var handler = new DeleteShipRequest.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.ShippingRequests.ToList();
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
