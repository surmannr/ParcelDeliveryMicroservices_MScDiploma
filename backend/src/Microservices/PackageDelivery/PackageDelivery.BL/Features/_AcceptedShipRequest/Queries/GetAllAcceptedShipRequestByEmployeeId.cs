using AutoMapper;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAllAcceptedShipRequestByEmployeeId
    {
        public class Query : IRequest<ICollection<AcceptedShippingRequestDto>>
        {
            public string EmployeeId { get; set; }
        }

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
                var vehicleUsage = await _acceptedShipping
                    .GetAcceptedShippingRequestsByEmployeeId(request.EmployeeId);

                return _mapper.Map<List<AcceptedShippingRequestDto>>(vehicleUsage);
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
