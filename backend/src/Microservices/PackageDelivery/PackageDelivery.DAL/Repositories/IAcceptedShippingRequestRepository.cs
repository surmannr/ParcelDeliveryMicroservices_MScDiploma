using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public interface IAcceptedShippingRequestRepository
    {
        Task<IEnumerable<AcceptedShippingRequest>> GetAcceptedShippingRequests();
        Task<AcceptedShippingRequest> GetAcceptedShippingRequestById(string id);

        Task CreateAcceptedShippingRequest(AcceptedShippingRequest shipping);
        Task<bool> UpdateAcceptedShippingRequest(AcceptedShippingRequest shipping);
        Task<bool> DeleteAcceptedShippingRequest(string id);
    }
}
