using Common.Dto;
using PackageSending.BL.Features._Currency.Commands;
using PackageSending.BL.Features._Currency.Queries;
using PackageSending.BL.Features._PaymentOption.Commands;
using PackageSending.BL.Features._PaymentOption.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests.UnitTests
{
    public class PaymentOptionUnitTests : UnitTestBase
    {
        public PaymentOptionUnitTests() : base() { }

        private PaymentOption element = new PaymentOption()
        {
            Id = 3,
            Name = "Kriptovaluta",
        };

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var query = new GetAllPaymentOptions.Query();
            var handler = new GetAllPaymentOptions.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.PaymentOption1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PagedResponse<PaymentOptionDto>>();
            result.TotalCount.ShouldBe(2);
            result.Data.Count.ShouldBe(2);

            result.Data.First().ShouldBeOfType<PaymentOptionDto>();
            result.Data.First().Name.ShouldBe(firstElement.Name);
            result.Data.First().Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            var id = 1;
            var query = new GetPaymentOptionById.Query() { Id = id };
            var handler = new GetPaymentOptionById.Handler(_mapper, _dbContext.Object);
            var firstElement = SeedData.PaymentOption1;

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<PaymentOptionDto>();
            result.Name.ShouldBe(firstElement.Name);
            result.Id.ShouldBe(firstElement.Id);
        }

        [Fact]
        public async Task Create()
        {
            // Arrange
            var query = new AddNewPaymentOption.Command() { NewPaymentOption = _mapper.Map<PaymentOptionDto>(element) };
            var handler = new AddNewPaymentOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<int>();

            var elements = _dbContext.Object.PaymentOptions.ToList();
            elements.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            element.Id = 2;
            element.Name = "Ingyen";
            var query = new EditPaymentOption.Command() { ModifiedPaymentOption = _mapper.Map<PaymentOptionDto>(element) };
            var handler = new EditPaymentOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.PaymentOptions.ToList();
            elements.Count.ShouldBe(2);
            elements.Any(x => x.Id == element.Id).ShouldBeTrue();
            elements.Where(x => x.Id == element.Id).First().Name.ShouldBe("Ingyen");
        }

        [Fact]
        public async Task Delete()
        {
            // Arrange
            var query = new DeletePaymentOption.Command() { Id = 1 };
            var handler = new DeletePaymentOption.Handler(_mapper, _dbContext.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.ShouldBeOfType<bool>();
            result.ShouldBeTrue();

            var elements = _dbContext.Object.PaymentOptions.ToList();
            elements.Count.ShouldBe(1);
            elements.Any(x => x.Id == element.Id).ShouldBeFalse();
        }
    }
}
