using AutoMapper;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Extensions.CQRS;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Commands
{
    public static class EditVehicle
    {
        public class Command : ICommand<bool>
        {
            public VehicleDto ModifiedVehicle { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle, IMapper mapper)
            {
                _vehicle = vehicle;
                _mapper = mapper;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = _mapper.Map<Vehicle>(request.ModifiedVehicle);

                return await _vehicle.UpdateVehicle(vehicle);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedVehicle.TechnicalInspectionExpirationDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A járművizsgálat lejárati dátuma nem lehet üres.");

                RuleFor(x => x.ModifiedVehicle.Year)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű évjárata nem lehet üres.");

                RuleFor(x => x.ModifiedVehicle.SeatingCapacity)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű ülések száma nem lehet üres.");

                RuleFor(x => x.ModifiedVehicle.RegistrationNumber)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű rendszáma nem lehet üres.");

                RuleFor(x => x.ModifiedVehicle.Type)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű típusa nem lehet üres.");

                RuleFor(x => x.ModifiedVehicle.MaxInternalSpaceX)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (X) nem lehet üres és negatív szám.");

                RuleFor(x => x.ModifiedVehicle.MaxInternalSpaceY)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (Y) nem lehet üres és negatív szám.");

                RuleFor(x => x.ModifiedVehicle.MaxInternalSpaceZ)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (Z) nem lehet üres és negatív szám.");
            }
        }
    }
}
