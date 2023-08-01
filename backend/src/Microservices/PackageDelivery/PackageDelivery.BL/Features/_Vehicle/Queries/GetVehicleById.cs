using AutoMapper;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Queries
{
    public static class GetVehicleById
    {
        public class Query : IRequest<VehicleDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, VehicleDto>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle, IMapper mapper)
            {
                _vehicle = vehicle;
                _mapper = mapper;
            }

            public async Task<VehicleDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var vehicleUsage = await _vehicle.GetVehicleById(request.Id);

                if (vehicleUsage == null) throw new NotFoundException("Nincs ilyen jármű a megadott azonosító alapján!");

                return _mapper.Map<VehicleDto>(vehicleUsage);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű azonosító nem lehet üres.");
            }
        }
    }
}
