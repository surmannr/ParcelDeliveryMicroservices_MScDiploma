using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Billing.Queries
{
    public static class GetBillingById
    {
        public class Query : IRequest<BillingDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, BillingDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<BillingDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var billing = await _dbContext
                    .Billings
                    .Include(b => b.Currency)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (billing == null) throw new NotFoundException("Nincs ilyen számla a megadott azonosító alapján!");

                return _mapper.Map<BillingDto>(billing);
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
