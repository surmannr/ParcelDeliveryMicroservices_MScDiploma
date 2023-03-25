using AutoMapper;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Extensions.CQRS;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Commands
{
    public static class AddNewAcceptedShipRequest
    {
        public class Command : ICommand<string>
        {
            public AcceptedShippingRequestDto NewAcceptedShipRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IMapper _mapper;
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IMapper mapper, IAcceptedShippingRequestRepository acceptedShipping)
            {
                _mapper = mapper;
                _acceptedShipping = acceptedShipping;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var acceptedShipReq = _mapper.Map<AcceptedShippingRequest>(request.NewAcceptedShipRequest);

                return await _acceptedShipping.CreateAcceptedShippingRequest(acceptedShipReq);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewAcceptedShipRequest.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");

                RuleFor(x => x.NewAcceptedShipRequest.Shipping)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("A szállítás nem lehet üres.");
            }
        }
    }
}
