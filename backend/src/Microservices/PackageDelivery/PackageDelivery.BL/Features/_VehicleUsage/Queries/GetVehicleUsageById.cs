using AutoMapper;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Queries
{
    public static class GetVehicleUsageById
    {
        public class Query : IRequest<VehicleUsageDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, VehicleUsageDto>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleUsageRepository _vehicleUsage;

            public Handler(IVehicleUsageRepository vehicleUsage, IMapper mapper)
            {
                _vehicleUsage = vehicleUsage;
                _mapper = mapper;
            }

            public async Task<VehicleUsageDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicleUsage = await _vehicleUsage
                    .GetVehicleUsageById(request.Id);

                if (vehicleUsage == null) throw new NotFoundException("Nincs ilyen járműhasználat a megadott alkalmazott azonosító alapján!");

                return _mapper.Map<VehicleUsageDto>(vehicleUsage);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
