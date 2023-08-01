using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._PaymentOption.Queries
{
    public static class GetAllPaymentOptions
    {
        public class Query : IRequest<List<PaymentOptionDto>> { }

        public class Handler : IRequestHandler<Query, List<PaymentOptionDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<PaymentOptionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.PaymentOptions
                    .ProjectTo<PaymentOptionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
