using PackageTracking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.DAL.Repositories
{
    public interface IPackageTrackingRepository
    {
        Task<Shipping> GetShipping(string id);
        Task<Shipping> UpdateShipping(Shipping shipping);
        Task DeleteShipping(string id);
    }
}
