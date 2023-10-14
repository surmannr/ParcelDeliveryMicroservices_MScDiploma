
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.UnitTests
{
    public class VehicleUsageUnitTests : UnitTestBase
    {
        private readonly Mock<IVehicleUsageRepository> _mockRepo;
        private readonly Mock<IVehicleRepository> _mockVehicleRepo;

        private readonly string byId = "teszt2";
        private readonly string employeeId = "tesztuserid";
        private readonly VehicleUsage element = MockVehicleUsageRepository.VehicleUsages.First();

        public VehicleUsageUnitTests() : base()
        {
            element.EmployeeName = "ChangeTestName";
            _mockRepo = MockVehicleUsageRepository.GetAcceptedShippingRequestRepository();
            _mockVehicleRepo = MockVehicleRepository.GetVehicleRepository();
        }

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllVehicleUsages.Query();
            var handler = new GetAllVehicleUsages.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockVehicleUsageRepository.VehicleUsages.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<VehicleUsageDto>>();
            result.TotalCount.ShouldBe(MockVehicleUsageRepository.PagedData.TotalCount);
            result.Data.Count.ShouldBe(MockVehicleUsageRepository.PagedData.Data.Count);

            result.Data.First().ShouldBeOfType<VehicleUsageDto>();
            result.Data.First().EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.Data.First().DateFrom.ShouldBe(firstElement.DateFrom);
            result.Data.First().DateTo.ShouldBe(firstElement.DateTo);
            result.Data.First().Note.ShouldBe(firstElement.Note);
            result.Data.First().Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task GetAllByEmployeeId()
        {
            // Arrange
            var query = new GetAllVehicleUsages.Query() { EmployeeId = employeeId };
            var handler = new GetAllVehicleUsages.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockVehicleUsageRepository.VehicleUsages.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<VehicleUsageDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<VehicleUsageDto>();
            result.Data.First().EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.Data.First().DateFrom.ShouldBe(firstElement.DateFrom);
            result.Data.First().DateTo.ShouldBe(firstElement.DateTo);
            result.Data.First().Note.ShouldBe(firstElement.Note);
            result.Data.First().Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var query = new GetVehicleUsageById.Query() { Id = byId };
            var handler = new GetVehicleUsageById.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockVehicleUsageRepository.VehicleUsages.First(x => x.Id == byId);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<VehicleUsageDto>();
            result.EmployeeName.ShouldBeSameAs(firstElement.EmployeeName);
            result.DateFrom.ShouldBe(firstElement.DateFrom);
            result.DateTo.ShouldBe(firstElement.DateTo);
            result.Note.ShouldBe(firstElement.Note);
            result.Vehicle.RegistrationNumber.ShouldBe(firstElement.Vehicle.RegistrationNumber);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var dto = _mapper.Map<NewVehicleUsageDto>(element);
            dto.VehicleId = element.Vehicle.Id;
            var query = new AddNewVehicleUsage.Command() { NewVehicleUsage = dto };
            var handler = new AddNewVehicleUsage.Handler(_mockRepo.Object, _mockVehicleRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();
            result.ShouldBe(element.Id);

            var elements = MockVehicleUsageRepository.PagedData_Create;
            elements.Data.Count.ShouldBe(3);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            var query = new EditVehicleUsage.Command() { ModifiedVehicleUsage = _mapper.Map<NewVehicleUsageDto>(element) };
            var handler = new EditVehicleUsage.Handler(_mockRepo.Object, _mockVehicleRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockVehicleUsageRepository.PagedData_Update;
            elements.Data.Count.ShouldBe(2);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Data.Where(x => x.Id == element.Id).First().EmployeeName.ShouldBe("ChangeTestName");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteVehicleUsage.Command() { Id = element.Id };
            var handler = new DeleteVehicleUsage.Handler(_mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockVehicleUsageRepository.PagedData_Delete;
            elements.Data.Count.ShouldBe(1);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
