using Common.Dto;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageSending.Tests.UnitTests
{
    public class BillingUnitTests : UnitTestBase
    {
        public BillingUnitTests() : base() { }

        private Billing element = new Billing()
        {
            Id = "bid3",
            CurrencyId = 1,
            Name = "Teszt3 Elek",
            UserId = "teszt3",
            TotalAmount = 2500,
            TotalDistance = 320,
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllBillings.Query();
            var handler = new GetAllBillings.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Billing1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<BillingDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<BillingDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().TotalAmount.ShouldBe(firstElement.TotalAmount);
            result.Data.First().TotalDistance.ShouldBe(firstElement.TotalDistance);
            result.Data.First().Currency.Name.ShouldBe(firstElement.Currency.Name);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task GetAllByUserId()
        {
            // Arrange
            var userId = "teszt1";
            var query = new GetAllBillingsByUserId.Query() { UserId = userId };
            var handler = new GetAllBillingsByUserId.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Billing1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<BillingDto>>();
            result.TotalCount.ShouldBe(1);
            result.Data.Count.ShouldBe(1);

            result.Data.First().ShouldBeOfType<BillingDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().TotalAmount.ShouldBe(firstElement.TotalAmount);
            result.Data.First().TotalDistance.ShouldBe(firstElement.TotalDistance);
            result.Data.First().Currency.Name.ShouldBe(firstElement.Currency.Name);
            result.Data.First().UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = "bid1";
            var query = new GetBillingById.Query() { Id = id };
            var handler = new GetBillingById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.Billing1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<BillingDto>();
            result.Name.ShouldBe(firstElement.Name);
            result.TotalAmount.ShouldBe(firstElement.TotalAmount);
            result.TotalDistance.ShouldBe(firstElement.TotalDistance);
            result.Currency.Name.ShouldBe(firstElement.Currency.Name);
            result.UserId.ShouldBe(firstElement.UserId);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewBilling.Command() { NewBilling = _mapper.Map<NewBillingDto>(element) };
            var handler = new AddNewBilling.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<string>();

            var elements = _dbContext.Object.Billings.ToList();
            elements.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = "bid1";
            element.TotalAmount = 20;
            var query = new EditBilling.Command() { ModifiedBilling = _mapper.Map<NewBillingDto>(element), Id = element.Id };
            var handler = new EditBilling.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Billings.ToList();
            elements.Count.ShouldBe(2);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().TotalAmount.ShouldBe(20);
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeleteBilling.Command() { Id = "bid1" };
            var handler = new DeleteBilling.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.Billings.ToList();
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
