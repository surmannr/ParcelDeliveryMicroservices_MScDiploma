using AutoMapper;
using Common.Dto;
using Common.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Exceptions;
using PackageSending.BL.Extensions.CQRS;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Package.Commands
{
    public static class AddNewPackage
    {
        public class Command : ICommand<string>
        {
            public PackageDto NewPackage { get; set; }
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
                var shipReq = await _dbContext.ShippingRequests
                    .FirstOrDefaultAsync(x => x.Id == request.NewPackage.ShippingRequestId);

                if (shipReq == null) throw new BadRequestException("Nincs ilyen rendelés!");

                var newPackage = _mapper.Map<Package>(request.NewPackage);
                newPackage.Id = Guid.NewGuid().ToString();

                var result = _dbContext.Packages.Add(newPackage);
                await _dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NewPackage.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A felhasználó azonosító nem lehet üres.");

                RuleFor(x => x.NewPackage.Weight)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A súly nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.NewPackage.SizeX)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A magasság nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.NewPackage.SizeY)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A szélesség nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.NewPackage.SizeZ)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A mélység nem lehet üres és nagyobbnak kell lennie 0-nál.");
            }
        }
    }
}
