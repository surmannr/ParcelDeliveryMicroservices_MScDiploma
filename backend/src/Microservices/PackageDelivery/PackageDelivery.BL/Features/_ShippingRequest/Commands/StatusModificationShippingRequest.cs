using AutoMapper;
using Common.Dto;
using Common.Entity;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using PackageDelivery.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Features._ShippingRequest.Commands
{
    public static class StatusModificationShippingRequest
    {
        public class Command : ICommand<bool>
        {
            public List<ShippingRequestDto> ShippingRequests { get; set; }
            public Status Status { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IShippingRequestRepository _repository;
            private readonly IMapper _mapper;
            public Handler(IShippingRequestRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var shippingRequests = _mapper.Map<List<ShippingRequest>>(request.ShippingRequests);

                if (!shippingRequests.Any())
                {
                    return false;
                }

                foreach (var shippingRequest in shippingRequests)
                {
                    shippingRequest.Status = request.Status;
                    await _repository.UpdateShippingRequest(shippingRequest);
                }

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ShippingRequests)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A lista nem lehet üres.");
            }
        }
    }
}
