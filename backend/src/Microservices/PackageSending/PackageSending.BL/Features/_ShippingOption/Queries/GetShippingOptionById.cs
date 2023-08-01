using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._ShippingOption.Queries
{
    public static class GetShippingOptionById
    {
        public class Query : IRequest<ShippingOptionDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ShippingOptionDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ShippingOptionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var shippingOption = await _dbContext
                    .ShippingOptions
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (shippingOption == null) throw new NotFoundException("Nincs ilyen szállítási mód a megadott azonosító alapján!");

                return _mapper.Map<ShippingOptionDto>(shippingOption);
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
