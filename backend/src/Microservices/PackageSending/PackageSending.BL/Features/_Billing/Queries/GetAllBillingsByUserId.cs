using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Billing.Queries
{
    public static class GetAllBillingsByUserId
    {
        public class Query : PagingParameter, IRequest<PagedResponse<BillingDto>> 
        {
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, PagedResponse<BillingDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<BillingDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Billings
                    .Where(x => x.UserId == request.UserId)
                    .ProjectTo<BillingDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A felhasználó azonosító nem lehet üres.");
            }
        }
    }
}
