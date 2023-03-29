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

namespace PackageSending.BL.Features._ShipRequest.Queries
{
    public static class GetAllShipRequestsByUserId
    {
        public class Query : IRequest<List<ShippingRequestDto>> 
        {
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ShippingRequestDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<ShippingRequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.ShippingRequests
                    .Where(x => x.UserId == request.UserId)
                    .ProjectTo<ShippingRequestDto>(_mapper.ConfigurationProvider)
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
