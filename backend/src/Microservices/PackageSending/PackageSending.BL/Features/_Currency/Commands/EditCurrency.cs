using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Currency.Commands
{
    public static class EditCurrency
    {
        public class Command : ICommand<bool>
        {
            public CurrencyDto ModifiedCurrency { get; set; }
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
                var currency = await _dbContext.Currencies
                    .FirstOrDefaultAsync(x => x.Id == request.ModifiedCurrency.Id);

                if (currency == null)
                {
                    throw new NotFoundException("Nincs ilyen valuta az azonosító alapján.");
                }

                if (!string.IsNullOrEmpty(request.ModifiedCurrency.Name))
                {
                    currency.Name = request.ModifiedCurrency.Name;
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedCurrency)
                    .NotNull()
                    .WithMessage("Nem lehet null érték.");
            }
        }
    }
}
