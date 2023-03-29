using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageSending.BL.Features._Billing.Queries
{
    public static class GetAllBillings
    {
        public class Query : IRequest<List<BillingDto>> { }

        public class Handler : IRequestHandler<Query, List<BillingDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<BillingDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Billings
                    .ProjectTo<BillingDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
