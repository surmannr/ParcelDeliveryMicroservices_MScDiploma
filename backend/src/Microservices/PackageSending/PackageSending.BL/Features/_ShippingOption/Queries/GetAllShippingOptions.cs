using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShippingOption.Queries
{
    public static class GetAllShippingOptions
    {
        public class Query : IRequest<List<ShippingOptionDto>> { }

        public class Handler : IRequestHandler<Query, List<ShippingOptionDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<ShippingOptionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.ShippingOptions
                    .ProjectTo<ShippingOptionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
