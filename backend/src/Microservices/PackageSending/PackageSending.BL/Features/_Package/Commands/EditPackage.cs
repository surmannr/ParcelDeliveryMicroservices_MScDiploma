using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using Common.Extension.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Package.Commands
{
    public static class EditPackage
    {
        public class Command : ICommand<bool>
        {
            public PackageDto ModifiedPackage { get; set; }
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
                var package = await _dbContext.Packages
                    .FirstOrDefaultAsync(x => x.Id == request.ModifiedPackage.Id);

                if (package == null)
                {
                    throw new NotFoundException("Nincs ilyen csomag az azonosító alapján.");
                }

                if (request.ModifiedPackage.SizeX > 0.0)
                {
                    package.SizeX = request.ModifiedPackage.SizeX;
                }
                if (request.ModifiedPackage.SizeY > 0.0)
                {
                    package.SizeY = request.ModifiedPackage.SizeY;
                }
                if (request.ModifiedPackage.SizeZ > 0.0)
                {
                    package.SizeZ = request.ModifiedPackage.SizeZ;
                }
                if (request.ModifiedPackage.Weight > 0.0)
                {
                    package.Weight = request.ModifiedPackage.Weight;
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {

                RuleFor(x => x.ModifiedPackage.Weight)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A súly nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.ModifiedPackage.SizeX)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A méret magasság nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.ModifiedPackage.SizeY)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A szélesség nem lehet üres és nagyobbnak kell lennie 0-nál.");

                RuleFor(x => x.ModifiedPackage.SizeZ)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A mélység nem lehet üres és nagyobbnak kell lennie 0-nál.");
            }
        }
    }
}
