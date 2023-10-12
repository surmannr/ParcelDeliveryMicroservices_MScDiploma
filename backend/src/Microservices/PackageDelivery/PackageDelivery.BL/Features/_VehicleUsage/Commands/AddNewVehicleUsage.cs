using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Commands
{
    public static class AddNewVehicleUsage
    {
        public class Command : ICommand<string>
        {
            public NewVehicleUsageDto NewVehicleUsage { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IVehicleUsageRepository _vehicleUsage;
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleUsageRepository vehicleUsage, IVehicleRepository vehicle)
            {
                _vehicleUsage = vehicleUsage;
                _vehicle = vehicle;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = await _vehicle.GetVehicleById(request.NewVehicleUsage.VehicleId);

                if (vehicle == null) throw new NotFoundException("Nincs ilyen jármű a megadott azonosítóval!");

                var vehicleUsage = new VehicleUsage()
                {
                    EmployeeId = request.NewVehicleUsage.EmployeeId,
                    EmployeeName = request.NewVehicleUsage.EmployeeName,
                    EmployeeEmail = request.NewVehicleUsage.EmployeeEmail,
                    DateFrom = request.NewVehicleUsage.DateFrom,
                    DateTo = request.NewVehicleUsage.DateTo,
                    Note = request.NewVehicleUsage.Note,
                    Vehicle = vehicle
                };

                return await _vehicleUsage.CreateVehicleUsage(vehicleUsage);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewVehicleUsage.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");

                RuleFor(x => x.NewVehicleUsage.VehicleId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A jármű azonosító nem lehet üres.");

                RuleFor(x => x.NewVehicleUsage.DateFrom)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A kezdeti dátum nem lehet üres.");

                RuleFor(x => x.NewVehicleUsage.DateTo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A befejezés dátum nem lehet üres.");

                RuleFor(x => x)
                    .Must(x => x.NewVehicleUsage.DateTo > x.NewVehicleUsage.DateFrom)
                    .WithMessage("A befejezés dátumának nagyobbnak kell lennie, mint a kezdeti dátum.");
            }
        }
    }
}
