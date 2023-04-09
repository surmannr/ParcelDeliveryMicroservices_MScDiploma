using AutoMapper;
using Common.Extension;
using PackageDelivery.BL.Dto;
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
            CreateMap<ShippingRequest, ShippingRequestDto>()
                .ForMember(x => x.Status, y => y.MapFrom(yd => yd.Status.GetDisplayName()))
                .ReverseMap();
            CreateMap<AcceptedShippingRequest, AcceptedShippingRequestDto>().ReverseMap();
        }
    }
}
