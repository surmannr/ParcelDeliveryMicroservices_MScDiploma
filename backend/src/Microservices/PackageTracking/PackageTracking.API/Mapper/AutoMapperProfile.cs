using AutoMapper;
using Common.Dto;
using Common.Entity;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;
using PackageTracking.DAL.Entities;

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
            CreateMap<Shipping, SendingPackageEvent>().ReverseMap();
            CreateMap<Address, AddressEO>().ReverseMap();
            CreateMap<Currency, CurrencyEO>().ReverseMap();
        }
    }
}
