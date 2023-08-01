using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._Vehicle.Commands
{
    public static class DeleteVehicle
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IVehicleRepository _vehicle;

            public Handler(IVehicleRepository vehicle)
            {
                _vehicle = vehicle;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _vehicle.DeleteVehicle(request.Id);
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
