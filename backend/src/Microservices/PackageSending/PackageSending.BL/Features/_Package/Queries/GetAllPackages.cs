using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageSending.BL.Features._Package.Queries
{
    public static class GetAllPackages
    {
        public class Query : IRequest<List<PackageDto>> { }

        public class Handler : IRequestHandler<Query, List<PackageDto>>
        {
            private readonly IMapper _mapper;
            private readonly PackageSendingDbContext _dbContext;

            public Handler(IMapper mapper, PackageSendingDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<PackageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Packages
                    .ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
