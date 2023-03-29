using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.BL.Exceptions;
using PackageSending.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageSending.BL.Features._ShipRequest.Queries
{
    public static class GetShipRequestById
    {
        public class Query : IRequest<ShippingRequestDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ShippingRequestDto>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ShippingRequestDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var shipReq = await _dbContext
                    .ShippingRequests
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (shipReq == null) throw new NotFoundException("Nincs ilyen rendelés a megadott azonosító alapján!");

                return _mapper.Map<ShippingRequestDto>(shipReq);
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
