using AutoMapper;
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

namespace PackageSending.BL.Features._Currency.Commands
{
    public static class AddNewCurrency
    {
        public class Command : ICommand<int>
        {
            public CurrencyDto NewCurrency { get; set; }
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
                var currency = await _dbContext.Currencies
                    .FirstOrDefaultAsync(x => x.Name.ToLower() == request.NewCurrency.Name.ToLower());

                if (currency != null) throw new BadRequestException("Már van ilyen valuta!");

                var newCurrency = _mapper.Map<Currency>(request.NewCurrency);

                var result = _dbContext.Currencies.Add(newCurrency);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewCurrency.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A valute neve nem lehet üres.");
            }
        }
    }
}
