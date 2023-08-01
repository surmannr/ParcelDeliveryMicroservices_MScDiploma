using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Common.Paging;
using MediatR;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Queries
{
    public static class GetAllShippingRequests
    {
        public class Query : PagingParameter, IRequest<PagedResponse<ShippingRequestDto>> { }

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
                var vehicles = await _repository.GetShippingRequests();
                return vehicles
                    .AsQueryable()
                    .ProjectTo<ShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }
    }
}
