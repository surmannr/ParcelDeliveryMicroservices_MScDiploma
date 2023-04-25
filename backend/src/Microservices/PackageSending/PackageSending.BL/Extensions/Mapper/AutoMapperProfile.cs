using AutoMapper;
using Common.Dto;
using Common.Entity;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;
using PackageSending.BL.Dto;

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
            CreateMap<ShippingRequest, SendingPackageEvent>().ReverseMap();
            CreateMap<Address, AddressEO>().ReverseMap();
            CreateMap<Billing, BillingEO>().ReverseMap();
            CreateMap<Currency, CurrencyEO>().ReverseMap();
        }
    }
}
