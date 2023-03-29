using AutoMapper;
using PackageSending.BL.Dto;
using PackageSending.DAL.Entities;

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
        }
    }
}
