using Common.Dto;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace PackageTracking.DAL.Repositories
{
    public class PackageTrackingRepository : IPackageTrackingRepository
    {
        private readonly IDistributedCache _redisCache;

        public PackageTrackingRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShippingRequestDto> GetShipping(string id)
        {
            var shipping = await _redisCache.GetStringAsync(id);
            
            if (string.IsNullOrEmpty(shipping))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShippingRequestDto>(shipping);
        }

        public async Task<ShippingRequestDto> UpdateShipping(ShippingRequestDto shipping)
        {
            var shippingJson = JsonConvert.SerializeObject(shipping);

            await _redisCache.SetStringAsync(shipping.Id, shippingJson);

            return await GetShipping(shipping.Id);
        }

        public async Task DeleteShipping(string id)
        {
            await _redisCache.RemoveAsync(id);
        }
    }
}
