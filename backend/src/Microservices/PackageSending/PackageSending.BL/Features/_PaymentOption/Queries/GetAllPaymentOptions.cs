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
