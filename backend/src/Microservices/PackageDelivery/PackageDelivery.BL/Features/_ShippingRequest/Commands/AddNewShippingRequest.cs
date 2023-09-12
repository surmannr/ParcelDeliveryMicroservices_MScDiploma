using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
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
                var shippingRequest = _mapper.Map<ShippingRequest>(request.NewShippingRequest);

                shippingRequest.DateOfDispatch = DateTime.UtcNow;

                return await _shippingRequestRepository.CreateShippingRequest(shippingRequest);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }
    }
}
