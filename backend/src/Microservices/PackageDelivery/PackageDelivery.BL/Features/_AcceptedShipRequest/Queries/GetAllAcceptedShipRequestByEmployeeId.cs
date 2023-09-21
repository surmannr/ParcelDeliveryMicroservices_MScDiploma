using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Filter;
using Common.Paging;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAllAcceptedShipRequestByEmployeeId
    {
        public class Query : AcceptedShippingRequestFilter, IRequest<PagedResponse<AcceptedShippingRequestDto>>
        {
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
                var acceptedShippingRequests = await _acceptedShipping
                    .GetAcceptedShippingRequestsByEmployeeId(request.EmployeeId, request);

                return new PagedResponse<AcceptedShippingRequestDto>()
                {
                    PageNumber = acceptedShippingRequests.PageNumber,
                    PageSize = acceptedShippingRequests.PageSize,
                    TotalCount = acceptedShippingRequests.TotalCount,
                    TotalPages = acceptedShippingRequests.TotalPages,
                    Data = acceptedShippingRequests.Data
                        .AsQueryable()
                        .ProjectTo<AcceptedShippingRequestDto>(_mapper.ConfigurationProvider)
                        .ToList(),
                };
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
