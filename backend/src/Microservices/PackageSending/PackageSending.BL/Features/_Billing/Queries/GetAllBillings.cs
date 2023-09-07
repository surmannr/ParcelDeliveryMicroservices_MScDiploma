using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using MediatR;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Billing.Queries
{
    public static class GetAllBillings
    {
        public class Query : BillingFilter, IRequest<PagedResponse<BillingDto>> { }

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
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<BillingDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
