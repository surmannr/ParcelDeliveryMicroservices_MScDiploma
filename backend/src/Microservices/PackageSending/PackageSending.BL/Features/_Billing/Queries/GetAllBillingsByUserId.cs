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
    public static class GetAllBillingsByUserId
    {
        public class Query : IRequest<List<BillingDto>> 
        {
            public string UserId { get; set; }
        }

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
                    .Where(x => x.UserId == request.UserId)
                    .ProjectTo<BillingDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A felhasználó azonosító nem lehet üres.");
            }
        }
    }
}
