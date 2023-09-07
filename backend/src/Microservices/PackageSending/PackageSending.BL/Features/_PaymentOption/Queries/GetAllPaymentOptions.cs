using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._PaymentOption.Queries
{
    public static class GetAllPaymentOptions
    {
        public class Query : PaymentOptionFilter, IRequest<PagedResponse<PaymentOptionDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<PaymentOptionDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PagedResponse<PaymentOptionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.PaymentOptions
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<PaymentOptionDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
            }
        }
    }
}
