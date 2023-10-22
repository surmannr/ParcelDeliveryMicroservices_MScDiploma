using AutoMapper;
using Common.Dto;
using Common.Entity;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;

namespace PackageTracking.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentOption, PaymentOptionDto>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();

            CreateMap<Package, PackageEO>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionEO>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionEO>().ReverseMap();
            CreateMap<ShippingRequest, SendingPackageEvent>().ReverseMap();
            CreateMap<ShippingRequestDto, SendingPackageEvent>().ReverseMap();
            CreateMap<Address, AddressEO>().ReverseMap();
            CreateMap<Currency, CurrencyEO>().ReverseMap();

            CreateMap<PackageDto, PackageEO>().ReverseMap();
            CreateMap<PaymentOptionDto, PaymentOptionEO>().ReverseMap();
            CreateMap<ShippingOptionDto, ShippingOptionEO>().ReverseMap();
            CreateMap<AddressDto, AddressEO>().ReverseMap();
            CreateMap<BillingDto, BillingEO>().ReverseMap();
            CreateMap<CurrencyDto, CurrencyEO>().ReverseMap();
        }
    }
}
