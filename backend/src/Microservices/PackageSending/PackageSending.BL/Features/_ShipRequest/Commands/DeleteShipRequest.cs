using AutoMapper;
using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShipRequest.Commands
{
    public static class DeleteShipRequest
    {
        public class Command : ICommand<bool>
        {
            public string Id { get; set; }
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
                var shippingRequest = await _dbContext
                    .ShippingRequests
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (shippingRequest == null) throw new NotFoundException("Nincs ilyen rendelés a megadott azonosító alapján!");

                _dbContext.ShippingRequests.Remove(shippingRequest);
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
