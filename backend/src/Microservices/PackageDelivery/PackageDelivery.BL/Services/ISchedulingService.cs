using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Services
{
    public interface ISchedulingService
    {
        public Task Schedule();
    }
}
