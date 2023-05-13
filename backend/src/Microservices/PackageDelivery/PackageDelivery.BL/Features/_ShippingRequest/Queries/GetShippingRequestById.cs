using AutoMapper;
using Common.Dto;
using FluentValidation;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Exceptions;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.BL.Features._ShippingRequest.Queries
{
    public static class GetShippingRequestById
    {
        public class Query : IRequest<ShippingRequestDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ShippingRequestDto>
        {
            private readonly IMapper _mapper;
            private readonly IShippingRequestRepository _repository;

            public Handler(IShippingRequestRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ShippingRequestDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var shippingRequest = await _repository.GetShippingRequestById(request.Id);

                if (shippingRequest == null) throw new NotFoundException("Nincs ilyen csomagfeladás!");

                return _mapper.Map<ShippingRequestDto>(shippingRequest);
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("A csomagfeladás azonosító nem lehet üres.");
            }
        }
    }
}
