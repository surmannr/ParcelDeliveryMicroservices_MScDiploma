using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Currency.Queries
{
    public static class GetCurrencyById
    {
        public class Query : IRequest<CurrencyDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CurrencyDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<CurrencyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var currency = await _dbContext
                    .Currencies
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (currency == null) throw new NotFoundException("Nincs ilyen pénznem a megadott azonosító alapján!");

                return _mapper.Map<CurrencyDto>(currency);
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
