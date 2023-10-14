using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq.EntityFrameworkCore;
using PackageSending.BL.Extensions.Mapper;
using PackageSending.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockQueryable.Moq;
using AutoMapper.QueryableExtensions;
using Common.Dto;

namespace PackageSending.Tests
{
    public class UnitTestBase
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<PackageSendingDbContext> _dbContext;

        public UnitTestBase()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            var dbContext = new Mock<PackageSendingDbContext>();

            dbContext.Setup(x => x.Billings).ReturnsDbSet(BillingsList);
            dbContext.Setup(x => x.Billings).Returns(BillingsList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.Billings.Add(It.IsAny<Billing>())).Returns((Billing entity) =>
            {
                BillingsList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object,entityTypeMock.Object, entity);
                var entry = new EntityEntry<Billing>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.Billings.Remove(It.IsAny<Billing>())).Callback((Billing entity) =>
            {
                BillingsList.Remove(entity);
            });
            dbContext.Setup(x => x.Billings.Update(It.IsAny<Billing>())).Callback((Billing entity) =>
            {
                var upd = BillingsList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            dbContext.Setup(x => x.Currencies).ReturnsDbSet(CurrenciesList);
            dbContext.Setup(x => x.Currencies).Returns(CurrenciesList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.Currencies.Add(It.IsAny<Currency>())).Returns((Currency entity) =>
            {
                CurrenciesList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object, entityTypeMock.Object, entity);
                var entry = new EntityEntry<Currency>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.Currencies.Remove(It.IsAny<Currency>())).Callback((Currency entity) =>
            {
                CurrenciesList.Remove(entity);
            });
            dbContext.Setup(x => x.Currencies.Update(It.IsAny<Currency>())).Callback((Currency entity) =>
            {
                var upd = CurrenciesList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            dbContext.Setup(x => x.Packages).ReturnsDbSet(PackagesList);
            dbContext.Setup(x => x.Packages).Returns(PackagesList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.Packages.Add(It.IsAny<Package>())).Returns((Package entity) =>
            {
                PackagesList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object, entityTypeMock.Object, entity);
                var entry = new EntityEntry<Package>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.Packages.Remove(It.IsAny<Package>())).Callback((Package entity) =>
            {
                PackagesList.Remove(entity);
            });
            dbContext.Setup(x => x.Packages.Update(It.IsAny<Package>())).Callback((Package entity) =>
            {
                var upd = PackagesList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            dbContext.Setup(x => x.PaymentOptions).ReturnsDbSet(PaymentOptionsList);
            dbContext.Setup(x => x.PaymentOptions).Returns(PaymentOptionsList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.PaymentOptions.Add(It.IsAny<PaymentOption>())).Returns((PaymentOption entity) =>
            {
                PaymentOptionsList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object, entityTypeMock.Object, entity);
                var entry = new EntityEntry<PaymentOption>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.PaymentOptions.Remove(It.IsAny<PaymentOption>())).Callback((PaymentOption entity) =>
            {
                PaymentOptionsList.Remove(entity);
            });
            dbContext.Setup(x => x.PaymentOptions.Update(It.IsAny<PaymentOption>())).Callback((PaymentOption entity) =>
            {
                var upd = PaymentOptionsList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            dbContext.Setup(x => x.ShippingOptions).ReturnsDbSet(ShippingOptionsList);
            dbContext.Setup(x => x.ShippingOptions).Returns(ShippingOptionsList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.ShippingOptions.Add(It.IsAny<ShippingOption>())).Returns((ShippingOption entity) =>
            {
                ShippingOptionsList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object, entityTypeMock.Object, entity);
                var entry = new EntityEntry<ShippingOption>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.ShippingOptions.Remove(It.IsAny<ShippingOption>())).Callback((ShippingOption entity) =>
            {
                ShippingOptionsList.Remove(entity);
            });
            dbContext.Setup(x => x.ShippingOptions.Update(It.IsAny<ShippingOption>())).Callback((ShippingOption entity) =>
            {
                var upd = ShippingOptionsList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            dbContext.Setup(x => x.ShippingRequests).ReturnsDbSet(ShippingRequestsList);
            dbContext.Setup(x => x.ShippingRequests).Returns(ShippingRequestsList.AsQueryable().BuildMockDbSet().Object);
            dbContext.Setup(x => x.ShippingRequests.Add(It.IsAny<ShippingRequest>())).Returns((ShippingRequest entity) =>
            {
                ShippingRequestsList.Add(entity);
                var stateManagerMock = new Mock<IStateManager>();
                var entityTypeMock = new Mock<IRuntimeEntityType>();
                entityTypeMock
                    .SetupGet(_ => _.EmptyShadowValuesFactory)
                    .Returns(() => new Mock<ISnapshot>().Object);
                entityTypeMock
                    .SetupGet(_ => _.Counts)
                    .Returns(new PropertyCounts(1, 1, 1, 1, 1, 1));
                entityTypeMock
                    .Setup(_ => _.GetProperties())
                    .Returns(Enumerable.Empty<IProperty>());
                var internalEntity = new InternalEntityEntry(stateManagerMock.Object, entityTypeMock.Object, entity);
                var entry = new EntityEntry<ShippingRequest>(internalEntity);
                return entry;
            });
            dbContext.Setup(x => x.ShippingRequests.Remove(It.IsAny<ShippingRequest>())).Callback((ShippingRequest entity) =>
            {
                ShippingRequestsList.Remove(entity);
            });
            dbContext.Setup(x => x.ShippingRequests.Update(It.IsAny<ShippingRequest>())).Callback((ShippingRequest entity) =>
            {
                var upd = ShippingRequestsList.FirstOrDefault(x => x.Id == entity.Id);
                upd = entity;
            });

            _dbContext = dbContext;
        }

        protected List<Billing> BillingsList { get; } = new List<Billing>() { SeedData.Billing1, SeedData.Billing2 };
        protected List<Currency> CurrenciesList { get; } = new List<Currency>() { SeedData.Currency1, SeedData.Currency2 };
        protected List<Package> PackagesList { get; } = new List<Package>() { SeedData.Package1, SeedData.Package2, SeedData.Package3, SeedData.Package4 };
        protected List<PaymentOption> PaymentOptionsList { get; } = new List<PaymentOption>() { SeedData.PaymentOption1, SeedData.PaymentOption2 };
        protected List<ShippingOption> ShippingOptionsList { get; } = new List<ShippingOption>() { SeedData.ShippingOption1, SeedData.ShippingOption2 };
        protected List<ShippingRequest> ShippingRequestsList { get; } = new List<ShippingRequest>() { SeedData.ShippingRequest1, SeedData.ShippingRequest2 };
    }
}
