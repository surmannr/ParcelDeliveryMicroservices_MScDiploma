using AutoMapper;
using Common.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.BL.Exceptions;
using PackageSending.BL.Extensions.CQRS;
using PackageSending.DAL;
using PackageSending.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageSending.BL.Features._ShipRequest.Commands
{
    public static class EditShipRequest
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
            public NewShippingRequestDto ModifiedShipping { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var shippingRequest = await _dbContext.ShippingRequests
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (shippingRequest == null)
                {
                    throw new NotFoundException("Nincs ilyen rendelés az azonosító alapján.");
                }

                if (request.ModifiedShipping.ShippingOptionId > 0)
                {
                    var shippingOption = await _dbContext.ShippingOptions
                        .FirstOrDefaultAsync(x => x.Id == request.ModifiedShipping.ShippingOptionId);

                    if (shippingOption == null) throw new BadRequestException("Nincs ilyen szállítási mód!");
                    shippingRequest.ShippingOptionId = request.ModifiedShipping.ShippingOptionId;
                }

                if (request.ModifiedShipping.PaymentOptionId > 0)
                {
                    var paymentOption = await _dbContext.PaymentOptions
                        .FirstOrDefaultAsync(x => x.Id == request.ModifiedShipping.PaymentOptionId);

                    if (paymentOption == null) throw new BadRequestException("Nincs ilyen fizetési mód!");
                    shippingRequest.ShippingOptionId = request.ModifiedShipping.ShippingOptionId;
                }

                if (!string.IsNullOrEmpty(request.ModifiedShipping.BillingId))
                {
                    var billing = await _dbContext.Billings
                        .FirstOrDefaultAsync(x => x.Id == request.ModifiedShipping.BillingId);

                    if (billing == null) throw new BadRequestException("Nincs ilyen számla!");
                    shippingRequest.ShippingOptionId = request.ModifiedShipping.ShippingOptionId;
                }

                if (!string.IsNullOrEmpty(request.ModifiedShipping.CourierId))
                {
                    shippingRequest.CourierId = request.ModifiedShipping.CourierId;
                }

                if (request.ModifiedShipping.AddressFrom != null)
                {
                    shippingRequest.AddressFrom = _mapper.Map<Address>(request.ModifiedShipping.AddressFrom);
                }

                if (request.ModifiedShipping.AddressTo != null)
                {
                    shippingRequest.AddressTo = _mapper.Map<Address>(request.ModifiedShipping.AddressTo);
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Az azonosító nem lehet üres érték.");
            }
        }
    }
}
