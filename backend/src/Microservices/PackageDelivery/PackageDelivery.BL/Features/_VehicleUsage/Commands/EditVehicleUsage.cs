using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Exceptions;
using PackageDelivery.BL.Extensions.CQRS;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Commands
{
    public static class EditVehicleUsage
    {
        public class Command : ICommand<bool>
        {
            public NewVehicleUsageDto ModifiedVehicleUsage { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IVehicleUsageRepository _vehicleUsage;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleUsageRepository vehicleUsage, IVehicleRepository vehicle)
            {
                _vehicleUsage = vehicleUsage;
                _vehicle = vehicle;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = await _vehicle.GetVehicleById(request.ModifiedVehicleUsage.VehicleId);

                if (vehicle == null) throw new NotFoundException("Nincs ilyen jármű a megadott azonosítóval!");

                var vehicleUsage = new VehicleUsage()
                {
                    Id = request.ModifiedVehicleUsage.Id,
                    EmployeeId = request.ModifiedVehicleUsage.EmployeeId,
                    DateFrom = request.ModifiedVehicleUsage.DateFrom,
                    DateTo = request.ModifiedVehicleUsage.DateTo,
                    Note = request.ModifiedVehicleUsage.Note,
                    Vehicle = vehicle
                };

                return await _vehicleUsage.UpdateVehicleUsage(vehicleUsage);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedVehicleUsage.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");

                RuleFor(x => x.ModifiedVehicleUsage.VehicleId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű azonosító nem lehet üres.");

                RuleFor(x => x.ModifiedVehicleUsage.DateFrom)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A kezdeti dátum nem lehet üres.");

                RuleFor(x => x.ModifiedVehicleUsage.DateTo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A befejezés dátum nem lehet üres.");

                RuleFor(x => x)
                    .Must(x => x.ModifiedVehicleUsage.DateTo > x.ModifiedVehicleUsage.DateFrom)
                    .WithMessage("A befejezés dátumának nagyobbnak kell lennie, mint a kezdeti dátum.");
            }
        }
    }
}
