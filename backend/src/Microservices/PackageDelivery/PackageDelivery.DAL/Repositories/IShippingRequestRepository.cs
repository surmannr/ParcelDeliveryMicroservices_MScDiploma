using Common.Entity;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public interface IShippingRequestRepository
    {
        Task<IEnumerable<ShippingRequest>> GetShippingRequests();
        Task<ShippingRequest> GetShippingRequestById(string id);

        Task<string> CreateShippingRequest(ShippingRequest shippingRequest);
        Task<bool> UpdateShippingRequest(ShippingRequest shippingRequest);
        Task<bool> DeleteShippingRequest(string id);
    }
}
