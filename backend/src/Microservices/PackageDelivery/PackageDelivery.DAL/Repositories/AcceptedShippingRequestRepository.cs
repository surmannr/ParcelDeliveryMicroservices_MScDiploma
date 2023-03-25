﻿using MongoDB.Driver;
using PackageDelivery.DAL.Entities;

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

        public async Task<IEnumerable<AcceptedShippingRequest>> GetAcceptedShippingRequestsByEmployeeId(string employeeId)
        {
            return await _context
                            .AcceptedShippingRequests
                            .Find(s => s.EmployeeId == employeeId)
                            .ToListAsync();
        }

        public async Task<string> CreateAcceptedShippingRequest(AcceptedShippingRequest shipping)
        {
            await _context.AcceptedShippingRequests.InsertOneAsync(shipping);

            return shipping.Id;
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
