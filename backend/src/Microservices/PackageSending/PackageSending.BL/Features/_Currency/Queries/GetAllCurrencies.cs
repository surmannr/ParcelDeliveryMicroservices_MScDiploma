using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Currency.Queries
{
    public static class GetAllCurrencies
    {
        public class Query : IRequest<List<CurrencyDto>> { }

        public class Handler : IRequestHandler<Query, List<CurrencyDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<CurrencyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Currencies
                    .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
