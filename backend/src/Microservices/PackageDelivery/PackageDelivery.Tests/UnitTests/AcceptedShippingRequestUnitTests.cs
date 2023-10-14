using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.UnitTests
{
    public class AcceptedShippingRequestUnitTests : UnitTestBase
    {
        private readonly Mock<IAcceptedShippingRequestRepository> _mockRepo;

        private readonly string byId = "teszt2";
        private readonly string employeeId = "tesztuserid";
        private readonly AcceptedShippingRequest element = MockAcceptedShippingRequestRepository.AcceptedShippingRequests.First();

        public AcceptedShippingRequestUnitTests() : base()
        {
            element.EmployeeName = "ChangeTestName";
            _mockRepo = MockAcceptedShippingRequestRepository.GetAcceptedShippingRequestRepository();
        }

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllAcceptedShipRequests.Query();
            var handler = new GetAllAcceptedShipRequests.Handler(_mapper, _mockRepo.Object);
            var firstElement = MockAcceptedShippingRequestRepository.AcceptedShippingRequests.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<AcceptedShippingRequestDto>>();
            result.TotalCount.ShouldBe(MockAcceptedShippingRequestRepository.PagedData.TotalCount);
            result.Data.Count.ShouldBe(MockAcceptedShippingRequestRepository.PagedData.Data.Count);

            result.Data.First().ShouldBeOfType<AcceptedShippingRequestDto>();
            result.Data.First().EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.Data.First().IsAllPackageTaken.ShouldBe(firstElement.IsAllPackageTaken);
            result.Data.First().ReadPackageIds.ShouldBeSameAs(firstElement.ReadPackageIds);
            result.Data.First().Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task GetAllByEmployeeId()
        {
            // Arrange
            var query = new GetAllAcceptedShipRequestByEmployeeId.Query() { EmployeeId = employeeId };
            var handler = new GetAllAcceptedShipRequestByEmployeeId.Handler(_mapper, _mockRepo.Object);
            var firstElement = MockAcceptedShippingRequestRepository.AcceptedShippingRequests.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<AcceptedShippingRequestDto>>();
            result.TotalCount.ShouldBe(1);
            result.Data.Count.ShouldBe(1);

            result.Data.First().ShouldBeOfType<AcceptedShippingRequestDto>();
            result.Data.First().EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.Data.First().IsAllPackageTaken.ShouldBe(firstElement.IsAllPackageTaken);
            result.Data.First().ReadPackageIds.ShouldBeSameAs(firstElement.ReadPackageIds);
            result.Data.First().Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var query = new GetAcceptedShipRequestById.Query() { Id = byId };
            var handler = new GetAcceptedShipRequestById.Handler(_mapper, _mockRepo.Object);
            var firstElement = MockAcceptedShippingRequestRepository.AcceptedShippingRequests.First(x => x.Id == byId);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<AcceptedShippingRequestDto>();
            result.EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.IsAllPackageTaken.ShouldBe(firstElement.IsAllPackageTaken);
            result.ReadPackageIds.ShouldBe(firstElement.ReadPackageIds);
            result.Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewAcceptedShipRequest.Command() { NewAcceptedShipRequest = _mapper.Map<AcceptedShippingRequestDto>(element) };
            var handler = new AddNewAcceptedShipRequest.Handler(_mapper, _mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();
            result.ShouldBe(element.Id);

            var elements = MockAcceptedShippingRequestRepository.PagedData_Create;
            elements.Data.Count.ShouldBe(3);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            var query = new EditAcceptedShipRequest.Command() { ModifiedAcceptedShipRequest = _mapper.Map<AcceptedShippingRequestDto>(element) };
            var handler = new EditAcceptedShipRequest.Handler(_mapper, _mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockAcceptedShippingRequestRepository.PagedData_Update;
            elements.Data.Count.ShouldBe(2);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Data.Where(x => x.Id == element.Id).First().EmployeeName.ShouldBe("ChangeTestName");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteAcceptedShipRequest.Command() { Id = element.Id };
            var handler = new DeleteAcceptedShipRequest.Handler(_mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockAcceptedShippingRequestRepository.PagedData_Delete;
            elements.Data.Count.ShouldBe(1);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
