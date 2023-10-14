using Common.Dto;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._Currency.Commands;
using PackageSending.BL.Features._Currency.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests.UnitTests
{
    public class CurrencyUnitTests : UnitTestBase
    {
        public CurrencyUnitTests() : base() { }

        private Currency element = new Currency()
        {
            Id = 3,
            Name = "Krajcár",
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllCurrencies.Query();
            var handler = new GetAllCurrencies.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Currency1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<CurrencyDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<CurrencyDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = 1;
            var query = new GetCurrencyById.Query() { Id = id };
            var handler = new GetCurrencyById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Currency1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<CurrencyDto>();
            result.Name.ShouldBe(firstElement.Name);
            result.Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewCurrency.Command() { NewCurrency = _mapper.Map<CurrencyDto>(element) };
            var handler = new AddNewCurrency.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<int>();

            var elements = _dbContext.Object.Currencies.ToList();
            elements.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = 2;
            element.Name = "Font";
            var query = new EditCurrency.Command() { ModifiedCurrency = _mapper.Map<CurrencyDto>(element) };
            var handler = new EditCurrency.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Currencies.ToList();
            elements.Count.ShouldBe(2);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().Name.ShouldBe("Font");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteCurrency.Command() { Id = 1 };
            var handler = new DeleteCurrency.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Currencies.ToList();
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
