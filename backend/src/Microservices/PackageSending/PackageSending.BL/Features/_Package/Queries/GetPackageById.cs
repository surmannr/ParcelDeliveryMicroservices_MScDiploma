using AutoMapper;
using Common.Dto;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Exceptions;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Package.Queries
{
    public static class GetPackageById
    {
        public class Query : IRequest<PackageDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PackageDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PackageDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var package = await _dbContext
                    .Packages
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (package == null) throw new NotFoundException("Nincs ilyen csomag a megadott azonosító alapján!");

                return _mapper.Map<PackageDto>(package);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
