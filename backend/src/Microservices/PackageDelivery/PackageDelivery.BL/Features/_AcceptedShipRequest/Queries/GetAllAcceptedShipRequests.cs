using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Paging;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAllAcceptedShipRequests
    {
        public class Query : PagingParameter, IRequest<PagedResponse<AcceptedShippingRequestDto>> { }

        public class Handler : IRequestHandler<Query, PagedResponse<AcceptedShippingRequestDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IMapper mapper, IAcceptedShippingRequestRepository acceptedShipping)
            {
                _mapper = mapper;
                _acceptedShipping = acceptedShipping;
            }

            public async Task<PagedResponse<AcceptedShippingRequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var acceptedShippingRequests = await _acceptedShipping.GetAcceptedShippingRequests();
                return acceptedShippingRequests
                    .AsQueryable()
                    .ProjectTo<AcceptedShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }
    }
}
