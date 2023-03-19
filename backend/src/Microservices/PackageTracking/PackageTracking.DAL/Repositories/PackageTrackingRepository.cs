using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PackageTracking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.DAL.Repositories
{
    public class PackageTrackingRepository : IPackageTrackingRepository
    {
        private readonly IDistributedCache _redisCache;

        public PackageTrackingRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<Shipping> GetShipping(string id)
        {
            var shipping = await _redisCache.GetStringAsync(id);
            
            if (string.IsNullOrEmpty(shipping))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Shipping>(shipping);
        }

        public async Task<Shipping> UpdateShipping(Shipping shipping)
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
