using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Queries
{
    public static class GetVehicleUsagesByEmployeeId
    {
        public class Query : PagingParameter, IRequest<PagedResponse<VehicleUsageDto>>
        {
            public string EmployeeId { get; set; }
        }

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
                var vehicleUsages = await _vehicleUsage
                    .GetVehicleUsageByEmployeeId(request.EmployeeId);

                return vehicleUsages
                    .AsQueryable()
                    .ProjectTo<VehicleUsageDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }

        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");
            }
        }
    }
}
