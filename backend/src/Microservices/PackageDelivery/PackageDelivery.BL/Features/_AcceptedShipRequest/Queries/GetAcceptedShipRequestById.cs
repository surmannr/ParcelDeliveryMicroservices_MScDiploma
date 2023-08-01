using AutoMapper;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._AcceptedShipRequest.Queries
{
    public static class GetAcceptedShipRequestById
    {
        public class Query : IRequest<AcceptedShippingRequestDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AcceptedShippingRequestDto>
        {
            private readonly IMapper _mapper;
            private readonly IAcceptedShippingRequestRepository _acceptedShipping;

            public Handler(IMapper mapper, IAcceptedShippingRequestRepository acceptedShipping)
            {
                _mapper = mapper;
                _acceptedShipping = acceptedShipping;
            }

            public async Task<AcceptedShippingRequestDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var acceptedShipReq = await _acceptedShipping
                    .GetAcceptedShippingRequestById(request.Id);

                if (acceptedShipReq == null) throw new NotFoundException("Nincs ilyen elfogadott kiszállítás a megadott alkalmazott azonosító alapján!");

                return _mapper.Map<AcceptedShippingRequestDto>(acceptedShipReq);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Az azonosító nem lehet üres.");
            }
        }
    }
}
