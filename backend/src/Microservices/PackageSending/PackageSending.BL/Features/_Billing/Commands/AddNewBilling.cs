using AutoMapper;
using Common.Entity;
using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Billing.Commands
{
    public static class AddNewBilling
    {
        public class Command : ICommand<string>
        {
            public NewBillingDto NewBilling { get; set; }
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
                var currency = await _dbContext.Currencies
                    .FirstOrDefaultAsync(x => x.Id == request.NewBilling.CurrencyId);

                if (currency == null) throw new BadRequestException("Nincs ilyen valuta!");

                var newBilling = _mapper.Map<Billing>(request.NewBilling);
                newBilling.Id = Guid.NewGuid().ToString();

                var result = _dbContext.Billings.Add(newBilling);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewBilling.TotalDistance)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A szállítási távolság nem lehet üres.");

                RuleFor(x => x.NewBilling.TotalAmount)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A szállítási költség nem lehet üres.");

                RuleFor(x => x.NewBilling.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A felhasználó azonosító nem lehet üres.");

                RuleFor(x => x.NewBilling.CurrencyId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A valuta azonosító nem lehet üres.");
            }
        }
    }
}
