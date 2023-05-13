using AutoMapper;
using Common.Dto;
using Common.Entity;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Extensions.CQRS;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Commands
{
    public static class AddNewShippingRequest
    {
        public class Command : ICommand<string>
        {
            public ShippingRequestDto NewShippingRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IMapper _mapper;
            private readonly IShippingRequestRepository _shippingRequestRepository;

            public Handler(IShippingRequestRepository repository, IMapper mapper)
            {
                _shippingRequestRepository = repository;
                _mapper = mapper;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = _mapper.Map<ShippingRequest>(request.NewShippingRequest);

                return await _shippingRequestRepository.CreateShippingRequest(vehicle);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewShippingRequest.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
