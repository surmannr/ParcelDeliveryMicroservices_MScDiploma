using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Commands
{
    public static class DeleteAcceptedShipRequest
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IAcceptedShippingRequestRepository acceptedShipping)
            {
                _acceptedShipping = acceptedShipping;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _acceptedShipping.DeleteAcceptedShippingRequest(request.Id);
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
