using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Entity.Filters;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._Currency.Queries;
using PackageSending.BL.Features._Package.Queries;
using PackageSending.BL.Features._PaymentOption.Queries;
using PackageSending.BL.Features._ShippingOption.Queries;
using PackageSending.BL.Features._ShipRequest.Queries;

namespace PackageSending.BL.Extensions.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionDto>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionDto>().ReverseMap();
            CreateMap<ShippingRequest, ShippingRequestDto>().ReverseMap();
            CreateMap<ShippingRequest, NewShippingRequestDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<Billing, NewBillingDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();

            CreateMap<Package, PackageEO>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionEO>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionEO>().ReverseMap();
            CreateMap<ShippingRequest, SendingPackageEvent>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreationDate, act => act.Ignore())
                .ForMember(dest => dest.ShippingRequestId, act => act.MapFrom(x => x.Id))
                .ReverseMap();
            CreateMap<Address, AddressEO>().ReverseMap();
            CreateMap<Billing, BillingEO>().ReverseMap();
            CreateMap<Currency, CurrencyEO>().ReverseMap();

            CreateMap<ShippingRequestFilter, GetAllShipRequests.Query>().ReverseMap();
            CreateMap<ShippingRequestFilter, GetAllShipRequestsByUserId.Query>().ReverseMap();
            CreateMap<BillingFilter, GetAllBillings.Query>().ReverseMap();
            CreateMap<BillingFilter, GetAllBillingsByUserId.Query>().ReverseMap();
            CreateMap<CurrencyFilter, GetAllCurrencies.Query>().ReverseMap();
            CreateMap<PaymentOptionFilter, GetAllPaymentOptions.Query>().ReverseMap();
            CreateMap<ShippingOptionFilter, GetAllShippingOptions.Query>().ReverseMap();
            CreateMap<PackageFilter, GetAllPackages.Query>().ReverseMap();
            CreateMap<PackageFilter, GetAllPackagesByShipReqId.Query>().ReverseMap();
        }
    }
}
