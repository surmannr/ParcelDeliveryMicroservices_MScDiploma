using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShippingOption.Queries
{
    public static class GetAllShippingOptions
    {
        public class Query : ShippingOptionFilter, IRequest<PagedResponse<ShippingOptionDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<ShippingOptionDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<ShippingOptionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.ShippingOptions
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<ShippingOptionDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
