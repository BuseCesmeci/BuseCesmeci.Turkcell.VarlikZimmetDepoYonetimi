using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.CacheExtension
{
    public static class StackExchangeRedisCache
    {

        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordKey,
            T recordValue,
            TimeSpan? absolutTime = null,
            TimeSpan? slidingTime = null)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = absolutTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingTime
            };

            var value = JsonSerializer.Serialize(recordValue);
            await cache.SetStringAsync(recordKey, value, options);
        }
        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordKey)
        {
            var data = await cache.GetStringAsync(recordKey);

            if (data is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
