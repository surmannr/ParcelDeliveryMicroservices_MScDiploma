using AutoMapper;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Exceptions;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Queries
{
    public static class GetVehicleUsagesByEmployeeId
    {
        public class Query : IRequest<ICollection<VehicleUsageDto>>
        {
            public string EmployeeId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ICollection<VehicleUsageDto>>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleUsageRepository _vehicleUsage;

            public Handler(IVehicleUsageRepository vehicleUsage, IMapper mapper)
            {
                _vehicleUsage = vehicleUsage;
                _mapper = mapper;
            }

            public async Task<ICollection<VehicleUsageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicleUsage = await _vehicleUsage
                    .GetVehicleUsageByEmployeeId(request.EmployeeId);

                return _mapper.Map<List<VehicleUsageDto>>(vehicleUsage);
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
