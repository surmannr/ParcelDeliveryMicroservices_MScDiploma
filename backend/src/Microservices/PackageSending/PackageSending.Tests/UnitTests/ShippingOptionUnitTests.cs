using Common.Dto;
using PackageSending.BL.Features._PaymentOption.Commands;
using PackageSending.BL.Features._PaymentOption.Queries;
using PackageSending.BL.Features._ShippingOption.Commands;
using PackageSending.BL.Features._ShippingOption.Queries;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests.UnitTests
{
    public class ShippingOptionUnitTests : UnitTestBase
    {
        public ShippingOptionUnitTests() : base() { }

        private ShippingOption element = new ShippingOption()
        {
            Id = 3,
            Name = "Teherautó + hajó",
            Price = 102200,
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllShippingOptions.Query();
            var handler = new GetAllShippingOptions.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.ShippingOption1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<ShippingOptionDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<ShippingOptionDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().Price.ShouldBe(firstElement.Price);
            result.Data.First().Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = 1;
            var query = new GetShippingOptionById.Query() { Id = id };
            var handler = new GetShippingOptionById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.ShippingOption1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<ShippingOptionDto>();
            result.Name.ShouldBe(firstElement.Name);
            result.Price.ShouldBe(firstElement.Price);
            result.Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewShippingOption.Command() { NewShippingOption = _mapper.Map<ShippingOptionDto>(element) };
            var handler = new AddNewShippingOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<int>();

            var elements = _dbContext.Object.ShippingOptions.ToList();
            elements.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = 2;
            element.Name = "Drón";
            var query = new EditShippingOption.Command() { ModifiedShippingOption = _mapper.Map<ShippingOptionDto>(element) };
            var handler = new EditShippingOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.ShippingOptions.ToList();
            elements.Count.ShouldBe(2);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().Name.ShouldBe("Drón");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteShippingOption.Command() { Id = 1 };
            var handler = new DeleteShippingOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.ShippingOptions.ToList();
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
