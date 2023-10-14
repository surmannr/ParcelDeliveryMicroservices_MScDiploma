using Common.Dto;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._Package.Commands;
using PackageSending.BL.Features._Package.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests.UnitTests
{
    public class PackageUnitTests : UnitTestBase
    {
        public PackageUnitTests() : base() { }

        private Package element = new Package()
        {
            Id = "pid5",
            IsFragile = true,
            SizeX = 100,
            SizeY = 100,
            SizeZ = 100,
            Weight = 200,
            UserId = "teszt1",
            ShippingRequestId = "sid1",
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllPackages.Query();
            var handler = new GetAllPackages.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Package1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<PackageDto>>();
            result.TotalCount.ShouldBe(4);
            result.Data.Count.ShouldBe(4);

            result.Data.First().ShouldBeOfType<PackageDto>();
            result.Data.First().SizeX.ShouldBe(firstElement.SizeX);
            result.Data.First().SizeY.ShouldBe(firstElement.SizeY);
            result.Data.First().SizeZ.ShouldBe(firstElement.SizeZ);
            result.Data.First().Weight.ShouldBe(firstElement.Weight);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
            result.Data.First().IsFragile.ShouldBe(firstElement.IsFragile);
        }

        [Fact]
        public async Task GetAllByShipReqId()
        {
            // Arrange
            var userId = "sid1";
            var query = new GetAllPackagesByShipReqId.Query() { ShipReqId = userId };
            var handler = new GetAllPackagesByShipReqId.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Package1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<PackageDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<PackageDto>();
            result.Data.First().SizeX.ShouldBe(firstElement.SizeX);
            result.Data.First().SizeY.ShouldBe(firstElement.SizeY);
            result.Data.First().SizeZ.ShouldBe(firstElement.SizeZ);
            result.Data.First().Weight.ShouldBe(firstElement.Weight);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
            result.Data.First().IsFragile.ShouldBe(firstElement.IsFragile);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = "pid1";
            var query = new GetPackageById.Query() { Id = id };
            var handler = new GetPackageById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Package1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PackageDto>();
            result.SizeX.ShouldBe(firstElement.SizeX);
            result.SizeY.ShouldBe(firstElement.SizeY);
            result.SizeZ.ShouldBe(firstElement.SizeZ);
            result.Weight.ShouldBe(firstElement.Weight);
            result.UserId.ShouldBe(firstElement.UserId);
            result.IsFragile.ShouldBe(firstElement.IsFragile);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewPackage.Command() { NewPackage = _mapper.Map<PackageDto>(element) };
            var handler = new AddNewPackage.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();

            var elements = _dbContext.Object.Packages.ToList();
            elements.Count.ShouldBe(5);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = "pid1";
            element.Weight = 50000;
            var query = new EditPackage.Command() { ModifiedPackage = _mapper.Map<PackageDto>(element) };
            var handler = new EditPackage.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Packages.ToList();
            elements.Count.ShouldBe(4);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().Weight.ShouldBe(50000);
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeletePackage.Command() { Id = "pid1" };
            var handler = new DeletePackage.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Packages.ToList();
            elements.Count.ShouldBe(3);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
