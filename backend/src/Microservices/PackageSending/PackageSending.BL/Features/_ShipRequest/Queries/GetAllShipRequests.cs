using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShipRequest.Queries
{
    public static class GetAllShipRequests
    {
        public class Query : PagingParameter, IRequest<PagedResponse<ShippingRequestDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<ShippingRequestDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<ShippingRequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.ShippingRequests
                    .ProjectTo<ShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
