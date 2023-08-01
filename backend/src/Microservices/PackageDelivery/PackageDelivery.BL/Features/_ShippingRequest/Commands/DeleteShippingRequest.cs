using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Commands
{
    public static class DeleteShippingRequest
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IShippingRequestRepository _repository;

            public Handler(IShippingRequestRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _repository.DeleteShippingRequest(request.Id);
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
