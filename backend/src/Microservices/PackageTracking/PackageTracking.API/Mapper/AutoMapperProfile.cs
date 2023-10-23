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
            CreateMap<Address, AddressEO>().ReverseMap();
            CreateMap<Currency, CurrencyEO>().ReverseMap();

            CreateMap<ShippingRequestDto, SendingPackageEvent>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreationDate, act => act.Ignore())
                .ForMember(dest => dest.ShippingRequestId, act => act.MapFrom(x => x.Id))
                .ReverseMap();
            CreateMap<PackageDto, PackageEO>().ReverseMap();
            CreateMap<BillingDto, BillingEO>().ReverseMap();
            CreateMap<PaymentOptionDto, PaymentOptionEO>().ReverseMap();
            CreateMap<ShippingOptionDto, ShippingOptionEO>().ReverseMap();
            CreateMap<AddressDto, AddressEO>().ReverseMap();
            CreateMap<CurrencyDto, CurrencyEO>().ReverseMap();
        }
    }
}
