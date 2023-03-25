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
    public static class EditAcceptedShipRequest
    {
        public class Command : ICommand<bool>
        {
            public AcceptedShippingRequestDto ModifiedAcceptedShipRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IMapper _mapper;
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IMapper mapper, IAcceptedShippingRequestRepository acceptedShipping)
            {
                _mapper = mapper;
                _acceptedShipping = acceptedShipping;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var acceptedShipReq = _mapper.Map<AcceptedShippingRequest>(request.ModifiedAcceptedShipRequest);

                return await _acceptedShipping.UpdateAcceptedShippingRequest(acceptedShipReq);
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedAcceptedShipRequest.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");

                RuleFor(x => x.ModifiedAcceptedShipRequest.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");

                RuleFor(x => x.ModifiedAcceptedShipRequest.Shipping)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("A szállítás nem lehet üres.");
            }
        }
    }
}
