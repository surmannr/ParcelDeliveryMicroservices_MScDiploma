using AutoMapper;
using Common.Dto;
using Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;

namespace PackageSending.BL.Features._PaymentOption.Queries
{
    public static class GetPaymentOptionById
    {
        public class Query : IRequest<PaymentOptionDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaymentOptionDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<PaymentOptionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var paymentOption = await _dbContext
                    .PaymentOptions
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (paymentOption == null) throw new NotFoundException("Nincs ilyen fizetési mód a megadott azonosító alapján!");

                return _mapper.Map<PaymentOptionDto>(paymentOption);
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
