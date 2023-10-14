using Common.Dto;
using PackageTracking.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Tests
{
    public class MockTrackingRepository : IPackageTrackingRepository
    {
        public List<ShippingRequestDto> ShippingRequests { get; set; }
        public MockTrackingRepository(List<ShippingRequestDto> _ShippingRequests)
        {
            ShippingRequests = _ShippingRequests;
        }

        public async Task DeleteShipping(string id)
        {
            var delData = ShippingRequests.FirstOrDefault(x => x.Id == id);
            if (delData != null)
            {
                ShippingRequests.Remove(delData);
            }
        }

        public async Task<ShippingRequestDto> GetShipping(string id)
        {
            var element = ShippingRequests.FirstOrDefault(x => x.Id == id);

            if (element == null) throw new Exception();

            return element;
        }

        public Task<ShippingRequestDto> UpdateShipping(ShippingRequestDto shipping)
        {
            var updData = ShippingRequests.FirstOrDefault(x => x.Id == shipping.Id);
            if (updData == null)
            {
                ShippingRequests.Add(shipping);
            }
            else
            {
                updData = shipping;
            }
            return Task.FromResult(shipping);
        }

    }
}
