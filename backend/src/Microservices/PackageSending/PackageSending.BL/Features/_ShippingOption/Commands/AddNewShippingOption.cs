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

namespace PackageSending.BL.Features._ShippingOption.Commands
{
    public static class AddNewShippingOption
    {
        public class Command : ICommand<int>
        {
            public ShippingOptionDto NewShippingOption { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var shippingOption = await _dbContext.PaymentOptions
                    .FirstOrDefaultAsync(x => x.Name.ToLower() == request.NewShippingOption.Name.ToLower());

                if (shippingOption != null) throw new BadRequestException("Már van ilyen szállítási mód!");

                var newShippingOption = _mapper.Map<ShippingOption>(request.NewShippingOption);

                var result = _dbContext.ShippingOptions.Add(newShippingOption);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewShippingOption.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A fizetési mód neve nem lehet üres.");

                RuleFor(x => x.NewShippingOption.Price)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A fizetési mód ára nem lehet üres.");
            }
        }
    }
}
