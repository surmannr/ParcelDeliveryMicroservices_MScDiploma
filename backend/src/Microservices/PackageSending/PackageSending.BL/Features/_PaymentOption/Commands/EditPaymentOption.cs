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

namespace PackageSending.BL.Features._PaymentOption.Commands
{
    public static class EditPaymentOption
    {
        public class Command : ICommand<bool>
        {
            public PaymentOptionDto ModifiedPaymentOption { get; set; }
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
                var paymentOption = await _dbContext.PaymentOptions
                    .FirstOrDefaultAsync(x => x.Id == request.ModifiedPaymentOption.Id);

                if (paymentOption == null)
                {
                    throw new NotFoundException("Nincs ilyen fizetési mód az azonosító alapján.");
                }

                if (!string.IsNullOrEmpty(request.ModifiedPaymentOption.Name))
                {
                    paymentOption.Name = request.ModifiedPaymentOption.Name;
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedPaymentOption)
                    .NotNull()
                    .WithMessage("Nem lehet null érték.");
            }
        }
    }
}
