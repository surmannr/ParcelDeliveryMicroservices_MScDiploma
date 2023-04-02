﻿using AutoMapper;
using Common.Dto;
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

namespace PackageSending.BL.Features._PaymentOption.Commands
{
    public static class AddNewPaymentOption
    {
        public class Command : ICommand<int>
        {
            public PaymentOptionDto NewPaymentOption { get; set; }
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
                var paymmentOption = await _dbContext.PaymentOptions
                    .FirstOrDefaultAsync(x => x.Name.ToLower() == request.NewPaymentOption.Name.ToLower());

                if (paymmentOption != null) throw new BadRequestException("Már van ilyen fizetési mód!");

                var newPaymentOption = _mapper.Map<PaymentOption>(request.NewPaymentOption);

                var result = _dbContext.PaymentOptions.Add(newPaymentOption);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewPaymentOption.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A fizetési mód neve nem lehet üres.");
            }
        }
    }
}
