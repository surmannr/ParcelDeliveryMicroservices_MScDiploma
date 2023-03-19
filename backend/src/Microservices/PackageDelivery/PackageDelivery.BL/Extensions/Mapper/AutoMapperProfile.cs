using AutoMapper;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Extensions.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<VehicleUsage, VehicleUsageDto>().ReverseMap();
            CreateMap<ShippingRequest, ShippingRequestDto>().ReverseMap();
            CreateMap<AcceptedShippingRequest, AcceptedShippingRequestDto>().ReverseMap();
        }
    }
}
