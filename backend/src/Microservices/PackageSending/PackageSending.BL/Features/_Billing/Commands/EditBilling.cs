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

namespace PackageSending.BL.Features._Billing.Commands
{
    public static class EditBilling
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
            public NewBillingDto ModifiedBilling { get; set; }
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
                var billing = await _dbContext.Billings
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (billing == null)
                {
                    throw new NotFoundException("Nincs ilyen számla az azonosító alapján.");
                }

                if (request.ModifiedBilling.TotalAmount > 0.0)
                {
                    billing.TotalAmount = request.ModifiedBilling.TotalAmount;
                }

                if (request.ModifiedBilling.TotalDistance > 0.0)
                {
                    billing.TotalDistance = request.ModifiedBilling.TotalDistance;
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedBilling.TotalDistance)
                    .NotNull()
                    .NotEmpty()
                    .Equal(0.0)
                    .WithMessage("A szállítási távolság nem lehet üres érték vagy 0.");

                RuleFor(x => x.ModifiedBilling.TotalAmount)
                    .NotNull()
                    .NotEmpty()
                    .Equal(0.0)
                    .WithMessage("A szállítási összeg nem lehet üres érték vagy 0.");

                RuleFor(x => x.Id)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Az azonosító nem lehet üres érték.");
            }
        }
    }
}
