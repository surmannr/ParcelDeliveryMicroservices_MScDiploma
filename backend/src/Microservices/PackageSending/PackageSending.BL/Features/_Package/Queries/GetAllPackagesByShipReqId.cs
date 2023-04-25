using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Paging;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._Package.Queries
{
    public static class GetAllPackagesByShipReqId
    {
        public class Query : PagingParameter, IRequest<PagedResponse<PackageDto>> 
        {
            public string ShipReqId { get; set; }
        }

        public class Handler : IRequestHandler<Query, PagedResponse<PackageDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<PackageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Packages
                    .Where(x => x.ShippingRequestId == request.ShipReqId)
                    .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
