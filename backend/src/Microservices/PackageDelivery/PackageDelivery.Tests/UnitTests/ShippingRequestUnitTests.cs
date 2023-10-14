using Common.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.UnitTests
{
    public class ShippingRequestUnitTests : UnitTestBase
    {
        private readonly Mock<IShippingRequestRepository> _mockRepo;

        private readonly string byId = "shipID1";
        private readonly string employeeId = "tesztuserid";
        private readonly ShippingRequest element = MockShippingRequestRepository.ShippingRequests.First();

        public ShippingRequestUnitTests() : base()
        {
            element.Status = Status.Cancelled;
            _mockRepo = MockShippingRequestRepository.GetShippingRequestRepository();
        }

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllShippingRequests.Query();
            var handler = new GetAllShippingRequests.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockShippingRequestRepository.ShippingRequests.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<ShippingRequestDto>>();
            result.TotalCount.ShouldBe(MockShippingRequestRepository.PagedData.TotalCount);
            result.Data.Count.ShouldBe(MockShippingRequestRepository.PagedData.Data.Count);

            result.Data.First().ShouldBeOfType<ShippingRequestDto>();
            result.Data.First().PaymentOption.Id.ShouldBe(firstElement.PaymentOption.Id);
            result.Data.First().ShippingOption.Name.ShouldBe(firstElement.ShippingOption.Name);
            result.Data.First().AddressFrom.Street.ShouldBe(firstElement.AddressFrom.Street);
            result.Data.First().AddressTo.Country.ShouldBe(firstElement.AddressTo.Country);
            result.Data.First().IsFinished.ShouldBe(firstElement.IsFinished);
            result.Data.First().IsExpress.ShouldBe(firstElement.IsExpress);
            result.Data.First().Email.ShouldBe(firstElement.Email);
            result.Data.First().CourierId.ShouldBe(firstElement.CourierId);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var query = new GetShippingRequestById.Query() { Id = byId };
            var handler = new GetShippingRequestById.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockShippingRequestRepository.ShippingRequests.First(x => x.Id == byId);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<ShippingRequestDto>();
            result.PaymentOption.Id.ShouldBe(firstElement.PaymentOption.Id);
            result.ShippingOption.Name.ShouldBe(firstElement.ShippingOption.Name);
            result.AddressFrom.Street.ShouldBe(firstElement.AddressFrom.Street);
            result.AddressTo.Country.ShouldBe(firstElement.AddressTo.Country);
            result.IsFinished.ShouldBe(firstElement.IsFinished);
            result.IsExpress.ShouldBe(firstElement.IsExpress);
            result.Email.ShouldBe(firstElement.Email);
            result.CourierId.ShouldBe(firstElement.CourierId);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewShippingRequest.Command() { NewShippingRequest = _mapper.Map<ShippingRequestDto>(element) };
            var handler = new AddNewShippingRequest.Handler(_mockRepo.Object, _mapper);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();
            result.ShouldBe(element.Id);

            var elements = MockShippingRequestRepository.PagedData_Create;
            elements.Data.Count.ShouldBe(3);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            var query = new EditShippingRequest.Command() { ModifiedShippingRequest = _mapper.Map<ShippingRequestDto>(element) };
            var handler = new EditShippingRequest.Handler(_mockRepo.Object, _mapper);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockShippingRequestRepository.PagedData_Update;
            elements.Data.Count.ShouldBe(2);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Data.Where(x => x.Id == element.Id).First().Status.ShouldBe(Status.Cancelled);
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteShippingRequest.Command() { Id = element.Id };
            var handler = new DeleteShippingRequest.Handler(_mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockShippingRequestRepository.PagedData_Delete;
            elements.Data.Count.ShouldBe(1);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
