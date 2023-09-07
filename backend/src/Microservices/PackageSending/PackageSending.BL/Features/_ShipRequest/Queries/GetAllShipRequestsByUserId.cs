using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShipRequest.Queries
{
    public static class GetAllShipRequestsByUserId
    {
        public class Query : ShippingRequestFilter, IRequest<PagedResponse<ShippingRequestDto>> 
        {
            public string UserId { get; set; }
        }

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
                    .Where(x => x.UserId == request.UserId)
                    .ExecuteFilterAndOrder(request)
                    .ProjectTo<ShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToPagedListAsync(request);
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
