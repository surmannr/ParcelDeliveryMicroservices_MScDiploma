using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._VehicleUsage.Commands
{
    public static class DeleteVehicleUsage
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IVehicleUsageRepository _vehicleUsage;

            public Handler(IVehicleUsageRepository vehicleUsage)
            {
                _vehicleUsage = vehicleUsage;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _vehicleUsage.DeleteVehicleUsage(request.Id);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
