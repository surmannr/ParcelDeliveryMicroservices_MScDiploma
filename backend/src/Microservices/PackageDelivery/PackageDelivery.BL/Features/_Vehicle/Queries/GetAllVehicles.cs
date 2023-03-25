using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Queries
{
    public static class GetAllVehicles
    {
        public class Query : IRequest<ICollection<VehicleDto>> { }

        public class Handler : IRequestHandler<Query, ICollection<VehicleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle, IMapper mapper)
            {
                _vehicle = vehicle;
                _mapper = mapper;
            }

            public async Task<ICollection<VehicleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicles = await _vehicle.GetVehicles();
                return vehicles
                    .AsQueryable()
                    .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
                    .ToList();
            }
        }
    }
}
