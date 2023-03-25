using AutoMapper;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Extensions.CQRS;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Commands
{
    public static class AddNewVehicle
    {
        public class Command : ICommand<string>
        {
            public VehicleDto NewVehicle { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IMapper _mapper;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle, IMapper mapper)
            {
                _vehicle = vehicle;
                _mapper = mapper;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = _mapper.Map<Vehicle>(request.NewVehicle);

                return await _vehicle.CreateVehicle(vehicle);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewVehicle.TechnicalInspectionExpirationDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A járművizsgálat lejárati dátuma nem lehet üres.");

                RuleFor(x => x.NewVehicle.Year)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű évjárata nem lehet üres.");

                RuleFor(x => x.NewVehicle.SeatingCapacity)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű ülések száma nem lehet üres.");

                RuleFor(x => x.NewVehicle.RegistrationNumber)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű rendszáma nem lehet üres.");

                RuleFor(x => x.NewVehicle.Type)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű típusa nem lehet üres.");

                RuleFor(x => x.NewVehicle.MaxInternalSpaceX)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (X) nem lehet üres és negatív szám.");

                RuleFor(x => x.NewVehicle.MaxInternalSpaceY)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (Y) nem lehet üres és negatív szám.");

                RuleFor(x => x.NewVehicle.MaxInternalSpaceZ)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("A jármű belső térfogata (Z) nem lehet üres és negatív szám.");
            }
        }
    }
}
