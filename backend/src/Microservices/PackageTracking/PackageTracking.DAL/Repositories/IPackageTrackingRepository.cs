using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.DAL.Repositories
{
    public interface IPackageTrackingRepository
    {
        Task<ShippingRequestDto> GetShipping(string id);
        Task<ShippingRequestDto> UpdateShipping(ShippingRequestDto shipping);
        Task DeleteShipping(string id);
    }
}
