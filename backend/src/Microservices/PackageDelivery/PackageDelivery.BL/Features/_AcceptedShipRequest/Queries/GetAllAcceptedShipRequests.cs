using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAllAcceptedShipRequests
    {
        public class Query : IRequest<ICollection<AcceptedShippingRequestDto>> { }

        public class Handler : IRequestHandler<Query, ICollection<AcceptedShippingRequestDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IMapper mapper, IAcceptedShippingRequestRepository acceptedShipping)
            {
                _mapper = mapper;
                _acceptedShipping = acceptedShipping;
            }

            public async Task<ICollection<AcceptedShippingRequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var acceptedShippingRequests = await _acceptedShipping.GetAcceptedShippingRequests();
                return acceptedShippingRequests
                    .AsQueryable()
                    .ProjectTo<AcceptedShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToList();
            }
        }
    }
}
