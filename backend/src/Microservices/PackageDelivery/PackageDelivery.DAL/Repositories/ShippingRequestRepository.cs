using Common.Entity;
using MongoDB.Driver;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.DAL.Repositories
{
    public class ShippingRequestRepository : IShippingRequestRepository
    {
        private readonly IPackageDeliveryContext _context;

        public ShippingRequestRepository(IPackageDeliveryContext context)
        {
            _context = context;
        }

        public async Task<string> CreateShippingRequest(ShippingRequest shippingRequest)
        {
            await _context.ShippingRequests.InsertOneAsync(shippingRequest);

            return shippingRequest.Id;
        }

        public async Task<bool> DeleteShippingRequest(string id)
        {
            FilterDefinition<ShippingRequest> filter = Builders<ShippingRequest>.Filter.Eq(s => s.Id, id);

            var deleteResult = await _context
                .ShippingRequests
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<ShippingRequest> GetShippingRequestById(string id)
        {
            return await _context
                            .ShippingRequests
                            .Find(s => s.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShippingRequest>> GetShippingRequests()
        {
            return await _context
                            .ShippingRequests
                            .Find(s => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateShippingRequest(ShippingRequest shippingRequest)
        {
            var updateResult = await _context
               .ShippingRequests
               .ReplaceOneAsync(filter: s => s.Id == shippingRequest.Id, replacement: shippingRequest);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
