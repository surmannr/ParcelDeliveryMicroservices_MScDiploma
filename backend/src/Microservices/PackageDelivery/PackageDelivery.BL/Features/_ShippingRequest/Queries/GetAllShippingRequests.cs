using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Entity.Filters;
using Common.Filter;
using Common.Paging;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Queries
{
    public static class GetAllShippingRequests
    {
        public class Query : ShippingRequestMongoFilter, IRequest<PagedResponse<ShippingRequestDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<ShippingRequestDto>>
        {
            private readonly IMapper _mapper;
            private readonly IShippingRequestRepository _repository;

            public Handler(IShippingRequestRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<ShippingRequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var shippingRequests = await _repository.GetShippingRequests(request);

                return new PagedResponse<ShippingRequestDto>()
                {
                    PageNumber = shippingRequests.PageNumber,
                    PageSize = shippingRequests.PageSize,
                    TotalCount = shippingRequests.TotalCount,
                    TotalPages = shippingRequests.TotalPages,
                    Data = shippingRequests.Data
                        .AsQueryable()
                        .ProjectTo<ShippingRequestDto>(_mapper.ConfigurationProvider)
                        .ToList(),
                };
            }
        }
    }
}
