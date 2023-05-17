﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Exceptions;
using PackageSending.BL.Extensions.CQRS;
using PackageSending.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageSending.BL.Features._Currency.Commands
{
    public static class DeleteCurrency
    {
        public class Command : ICommand<bool>
        {
            public int Id { get; set; }
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
                var currency = await _dbContext
                    .Currencies
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (currency == null) throw new NotFoundException("Nincs ilyen pénznem a megadott azonosító alapján!");

                _dbContext.Currencies.Remove(currency);
                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}