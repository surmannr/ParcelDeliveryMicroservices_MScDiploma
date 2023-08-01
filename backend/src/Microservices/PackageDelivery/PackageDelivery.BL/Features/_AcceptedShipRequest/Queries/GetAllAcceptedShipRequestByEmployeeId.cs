using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAllAcceptedShipRequestByEmployeeId
    {
        public class Query : PagingParameter, IRequest<PagedResponse<AcceptedShippingRequestDto>>
        {
            public string EmployeeId { get; set; }
        }

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
                var acceptedShippings = await _acceptedShipping
                    .GetAcceptedShippingRequestsByEmployeeId(request.EmployeeId);

                return acceptedShippings
                    .AsQueryable()
                    .ProjectTo<AcceptedShippingRequestDto>(_mapper.ConfigurationProvider)
                    .ToPagedList(request);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.EmployeeId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Az alkalmazott azonosító nem lehet üres.");
            }
        }
    }
}
