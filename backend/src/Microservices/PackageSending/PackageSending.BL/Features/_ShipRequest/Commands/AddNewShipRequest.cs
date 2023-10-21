using AutoMapper;
using Common.Entity;
using Common.Exceptions;
using Common.Extension.CQRS;
using EventBus.Messages.Events;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShipRequest.Commands
{
    public static class AddNewShipRequest
    {
        public class Command : ICommand<string>
        {
            public NewShippingRequestDto NewShipRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;
            private readonly IPublishEndpoint _publishEndpoint;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext, IPublishEndpoint publishEndpoint)
            {
                _mapper = mapper;
                _dbContext = dbContext;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var billing = await _dbContext.Billings
                    .FirstOrDefaultAsync(x => x.Id == request.NewShipRequest.BillingId);

                if (billing == null) throw new BadRequestException("Nincs ilyen számla!");

                var paymentOption = await _dbContext.PaymentOptions
                    .FirstOrDefaultAsync(x => x.Id == request.NewShipRequest.PaymentOptionId);

                if (paymentOption == null) throw new BadRequestException("Nincs ilyen fizetési mód!");

                var shippingOption = await _dbContext.ShippingOptions
                    .FirstOrDefaultAsync(x => x.Id == request.NewShipRequest.ShippingOptionId);

                if (shippingOption == null) throw new BadRequestException("Nincs ilyen szállítási mód!");

                var newShipRequest = _mapper.Map<ShippingRequest>(request.NewShipRequest);
                newShipRequest.Id = Guid.NewGuid().ToString();
                newShipRequest.Status = Status.Processing;

                var result = _dbContext.ShippingRequests.Add(newShipRequest);
                await _dbContext.SaveChangesAsync();

                // Event
                var eventMessage = _mapper.Map<SendingPackageEvent>(result.Entity);
                eventMessage.ShippingRequestId = result.Entity.Id;
                await _publishEndpoint.Publish(eventMessage);

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewShipRequest.AddressFrom)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A cím (honnan) nem lehet üres.");

                RuleFor(x => x.NewShipRequest.AddressTo)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("A cím (hová) nem lehet üres.");

                RuleFor(x => x.NewShipRequest.ShippingOptionId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A szállítási mód nem lehet üres.");

                RuleFor(x => x.NewShipRequest.PaymentOptionId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A fizetési mód nem lehet üres.");

                RuleFor(x => x.NewShipRequest.BillingId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A számla nem lehet üres.");

                RuleFor(x => x.NewShipRequest.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A felhasználó nem lehet üres.");
            }
        }
    }
}
