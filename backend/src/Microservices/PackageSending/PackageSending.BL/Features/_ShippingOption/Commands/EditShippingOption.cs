using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShippingOption.Commands
{
    public static class EditShippingOption
    {
        public class Command : ICommand<bool>
        {
            public ShippingOptionDto ModifiedShippingOption { get; set; }
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
                var shippingOption = await _dbContext.ShippingOptions
                    .FirstOrDefaultAsync(x => x.Id == request.ModifiedShippingOption.Id);

                if (shippingOption == null)
                {
                    throw new NotFoundException("Nincs ilyen szállítási mód az azonosító alapján.");
                }

                if (!string.IsNullOrEmpty(request.ModifiedShippingOption.Name))
                {
                    shippingOption.Name = request.ModifiedShippingOption.Name;
                }
                if (request.ModifiedShippingOption.Price > 0)
                {
                    shippingOption.Price = request.ModifiedShippingOption.Price;
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ModifiedShippingOption)
                    .NotNull()
                    .WithMessage("Nem lehet null érték.");
            }
        }
    }
}
