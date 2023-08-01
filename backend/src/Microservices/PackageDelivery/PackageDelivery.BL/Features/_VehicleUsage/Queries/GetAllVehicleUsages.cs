﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Paging;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Queries
{
    public static class GetAllVehicleUsages
    {
        public class Query : PagingParameter, IRequest<PagedResponse<VehicleUsageDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<VehicleUsageDto>>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleUsageRepository _vehicleUsage;

            public Handler(IVehicleUsageRepository vehicleUsage, IMapper mapper)
            {
                _vehicleUsage = vehicleUsage;
                _mapper = mapper;
            }

            public async Task<PagedResponse<VehicleUsageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicleUsages = await _vehicleUsage.GetVehicleUsages();
                return vehicleUsages
                    .AsQueryable()
                    .ProjectTo<VehicleUsageDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }
    }
}
