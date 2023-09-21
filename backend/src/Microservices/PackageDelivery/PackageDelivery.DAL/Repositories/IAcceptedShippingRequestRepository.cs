using Common.Paging;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.DAL.Repositories
{
    public interface IAcceptedShippingRequestRepository
    {
        Task<PagedResponse<AcceptedShippingRequest>> GetAcceptedShippingRequests(AcceptedShippingRequestFilter filter);
        Task<PagedResponse<AcceptedShippingRequest>> GetAcceptedShippingRequestsByEmployeeId(string employeeId, AcceptedShippingRequestFilter filter);
        Task<AcceptedShippingRequest> GetAcceptedShippingRequestById(string id);

        Task<string> CreateAcceptedShippingRequest(AcceptedShippingRequest shipping);
        Task<bool> UpdateAcceptedShippingRequest(AcceptedShippingRequest shipping);
        Task<bool> DeleteAcceptedShippingRequest(string id);
    }
}
