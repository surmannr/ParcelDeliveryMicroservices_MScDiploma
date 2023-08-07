using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Entity.Filters;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._ShippingRequest.Queries;
using PackageDelivery.DAL.Entities;

namespace PackageDelivery.BL.Extensions.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleUsage, VehicleUsageDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionDto>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionDto>().ReverseMap();
            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<ShippingRequest, ShippingRequestDto>()
                .ReverseMap();
            CreateMap<AcceptedShippingRequest, AcceptedShippingRequestDto>().ReverseMap();

            CreateMap<ShippingRequestFilter, GetAllShippingRequests.Query>().ReverseMap();
        }
    }
}
