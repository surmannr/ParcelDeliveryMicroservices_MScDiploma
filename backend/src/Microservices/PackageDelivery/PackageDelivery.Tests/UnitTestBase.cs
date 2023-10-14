using AutoMapper;
using PackageDelivery.BL.Extensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Tests
{
    public abstract class UnitTestBase
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
