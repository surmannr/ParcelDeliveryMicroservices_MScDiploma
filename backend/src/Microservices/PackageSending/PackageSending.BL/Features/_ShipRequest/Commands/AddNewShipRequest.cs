﻿using AutoMapper;
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

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
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

                var result = _dbContext.ShippingRequests.Add(newShipRequest);
                await _dbContext.SaveChangesAsync();

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
