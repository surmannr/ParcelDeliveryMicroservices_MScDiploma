using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Commands
{
    public static class EditShippingRequest
    {
        public class Command : ICommand<bool>
        {
            public ShippingRequestDto ModifiedShippingRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IMapper _mapper;
            private readonly IShippingRequestRepository _repository;

            public Handler(IShippingRequestRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var shippingRequest = _mapper.Map<ShippingRequest>(request.ModifiedShippingRequest);

                return await _repository.UpdateShippingRequest(shippingRequest);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedShippingRequest.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
