using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Filter;
using Common.Paging;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities.Filters;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Queries
{
    public static class GetAllVehicles
    {
        public class Query : VehicleFilter, IRequest<PagedResponse<VehicleDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<VehicleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle, IMapper mapper)
            {
                _vehicle = vehicle;
                _mapper = mapper;
            }

            public async Task<PagedResponse<VehicleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicles = await _vehicle.GetVehicles();
                return vehicles
                    .AsQueryable()
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }
    }
}
