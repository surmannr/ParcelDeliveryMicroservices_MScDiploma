using AutoMapper;
using Common.Dto;
using PackageTracking.API.Mapper;
using PackageTracking.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Tests
{
    public class UnitTestBase
    {
        protected readonly IMapper _mapper;

        public UnitTestBase()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
    }
}
