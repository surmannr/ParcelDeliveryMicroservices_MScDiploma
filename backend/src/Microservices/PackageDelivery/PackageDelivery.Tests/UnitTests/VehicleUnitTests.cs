using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests.UnitTests
{
    public class VehicleUnitTests : UnitTestBase
    {
        private readonly Mock<IVehicleRepository> _mockRepo;

        private readonly string byId = "vehicleID1";
        private readonly Vehicle element = MockVehicleRepository.Vehicles.First();

        public VehicleUnitTests() : base()
        {
            element.RegistrationNumber = "AAA-111";
            _mockRepo = MockVehicleRepository.GetVehicleRepository();
        }

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllVehicles.Query();
            var handler = new GetAllVehicles.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockVehicleRepository.Vehicles.First();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<VehicleDto>>();
            result.TotalCount.ShouldBe(MockVehicleRepository.PagedData.TotalCount);
            result.Data.Count.ShouldBe(MockVehicleRepository.PagedData.Data.Count);

            result.Data.First().ShouldBeOfType<VehicleDto>();
            result.Data.First().RegistrationNumber.ShouldBe(firstElement.RegistrationNumber);
            result.Data.First().Type.ShouldBe(firstElement.Type);
            result.Data.First().SeatingCapacity.ShouldBe(firstElement.SeatingCapacity);
            result.Data.First().MaxInternalSpaceX.ShouldBe(firstElement.MaxInternalSpaceX);
            result.Data.First().TechnicalInspectionExpirationDate.ShouldBe(firstElement.TechnicalInspectionExpirationDate);
            result.Data.First().Year.ShouldBe(firstElement.Year);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var query = new GetVehicleById.Query() { Id = byId };
            var handler = new GetVehicleById.Handler(_mockRepo.Object, _mapper);
            var firstElement = MockVehicleRepository.Vehicles.First(x => x.Id == byId);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<VehicleDto>();
            result.RegistrationNumber.ShouldBe(firstElement.RegistrationNumber);
            result.Type.ShouldBe(firstElement.Type);
            result.SeatingCapacity.ShouldBe(firstElement.SeatingCapacity);
            result.MaxInternalSpaceX.ShouldBe(firstElement.MaxInternalSpaceX);
            result.TechnicalInspectionExpirationDate.ShouldBe(firstElement.TechnicalInspectionExpirationDate);
            result.Year.ShouldBe(firstElement.Year);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewVehicle.Command() { NewVehicle = _mapper.Map<VehicleDto>(element) };
            var handler = new AddNewVehicle.Handler(_mockRepo.Object, _mapper);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();
            result.ShouldBe(element.Id);

            var elements = MockVehicleRepository.PagedData_Create;
            elements.Data.Count.ShouldBe(3);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            var query = new EditVehicle.Command() { ModifiedVehicle = _mapper.Map<VehicleDto>(element) };
            var handler = new EditVehicle.Handler(_mockRepo.Object, _mapper);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockVehicleRepository.PagedData_Update;
            elements.Data.Count.ShouldBe(2);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Data.Where(x => x.Id == element.Id).First().RegistrationNumber.ShouldBe("AAA-111");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteVehicle.Command() { Id = element.Id };
            var handler = new DeleteVehicle.Handler(_mockRepo.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = MockVehicleRepository.PagedData_Delete;
            elements.Data.Count.ShouldBe(1);
            elements.Data.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
