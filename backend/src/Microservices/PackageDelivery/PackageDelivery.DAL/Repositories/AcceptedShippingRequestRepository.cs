using MongoDB.Driver;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public class AcceptedShippingRequestRepository : IAcceptedShippingRequestRepository
    {
        private readonly IPackageDeliveryContext _context;

        public AcceptedShippingRequestRepository(IPackageDeliveryContext context)
        {
            _context = context;
        }

        public async Task<AcceptedShippingRequest> GetAcceptedShippingRequestById(string id)
        {
            return await _context
                            .AcceptedShippingRequests
                            .Find(s => s.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AcceptedShippingRequest>> GetAcceptedShippingRequests()
        {
            return await _context
                            .AcceptedShippingRequests
                            .Find(s => true)
                            .ToListAsync();
        }

        public async Task CreateAcceptedShippingRequest(AcceptedShippingRequest shipping)
        {
            await _context.AcceptedShippingRequests.InsertOneAsync(shipping);
        }

        public async Task<bool> DeleteAcceptedShippingRequest(string id)
        {
            FilterDefinition<AcceptedShippingRequest> filter = Builders<AcceptedShippingRequest>.Filter.Eq(s => s.Id, id);

            var deleteResult = await _context
                .AcceptedShippingRequests
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateAcceptedShippingRequest(AcceptedShippingRequest shipping)
        {
            var updateResult = await _context
               .AcceptedShippingRequests
               .ReplaceOneAsync(filter: s => s.Id == shipping.Id, replacement: shipping);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
