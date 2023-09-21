using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Filter;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities.Filters;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Queries
{
    public static class GetVehicleUsagesByEmployeeId
    {
        public class Query : VehicleUsageFilter, IRequest<PagedResponse<VehicleUsageDto>>
        {
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
                    .GetVehicleUsageByEmployeeId(request.EmployeeId, request);

                return new PagedResponse<VehicleUsageDto>()
                {
                    PageNumber = vehicleUsages.PageNumber,
                    PageSize = vehicleUsages.PageSize,
                    TotalCount = vehicleUsages.TotalCount,
                    TotalPages = vehicleUsages.TotalPages,
                    Data = vehicleUsages.Data
                        .AsQueryable()
                        .ProjectTo<VehicleUsageDto>(_mapper.ConfigurationProvider)
                        .ToList(),
                };
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
