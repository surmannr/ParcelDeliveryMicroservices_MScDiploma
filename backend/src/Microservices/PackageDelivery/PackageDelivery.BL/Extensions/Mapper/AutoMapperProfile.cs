using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Entity.Filters;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._AcceptedShipRequest.Queries;
using PackageDelivery.BL.Features._ShippingRequest.Queries;
using PackageDelivery.BL.Features._Vehicle.Queries;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.BL.Extensions.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleUsage, VehicleUsageDto>().ReverseMap();
            CreateMap<VehicleUsage, NewVehicleUsageDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionDto>().ReverseMap();
            CreateMap<ShippingOption, ShippingOptionDto>().ReverseMap();
            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<ShippingRequest, ShippingRequestDto>().ReverseMap();
            CreateMap<AcceptedShippingRequest, AcceptedShippingRequestDto>().ReverseMap();

            CreateMap<ShippingRequestFilter, GetAllShippingRequests.Query>().ReverseMap();
            CreateMap<VehicleFilter, GetAllVehicles.Query>().ReverseMap();
            CreateMap<AcceptedShippingRequestFilter, GetAllAcceptedShipRequests.Query>().ReverseMap();
            CreateMap<AcceptedShippingRequestFilter, GetAllAcceptedShipRequestByEmployeeId.Query>().ReverseMap();
            CreateMap<VehicleUsageFilter, GetAllVehicleUsages.Query>().ReverseMap();
            CreateMap<VehicleUsageFilter, GetVehicleUsagesByEmployeeId.Query>().ReverseMap();

            CreateMap<ShippingRequestDto, SendingPackageEvent>().ReverseMap();
            CreateMap<PackageDto, PackageEO>().ReverseMap();
            CreateMap<BillingDto, BillingEO>().ReverseMap();
            CreateMap<PaymentOptionDto, PaymentOptionEO>().ReverseMap();
            CreateMap<ShippingOptionDto, ShippingOptionEO>().ReverseMap();
            CreateMap<AddressDto, AddressEO>().ReverseMap();
            CreateMap<CurrencyDto, CurrencyEO>().ReverseMap();
        }
    }
}
