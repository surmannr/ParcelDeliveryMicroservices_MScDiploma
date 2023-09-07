using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Currency.Queries
{
    public static class GetAllCurrencies
    {
        public class Query : CurrencyFilter, IRequest<PagedResponse<CurrencyDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<CurrencyDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<CurrencyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Currencies
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
