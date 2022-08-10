using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace RepositoryLayer.Databases.Cache;

public class DistributedCache : ICache
{
    private readonly IDistributedCache _cache; 

    public DistributedCache(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> Get<T> (string key) 
        where T : class
    {
        var cachedResponse = await _cache.GetStringAsync(key);
        return cachedResponse == null ? null : JsonConvert.DeserializeObject<T>
        (
            cachedResponse,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
        );
    }

    public async Task Set<T> (T? value, CacheParams cacheParams) 
        where T : class
    {
        var response = JsonConvert.SerializeObject(value, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        await _cache.SetStringAsync(cacheParams.Key, response, new DistributedCacheEntryOptions(){
            SlidingExpiration = cacheParams.SlidingExpiration,
            AbsoluteExpiration = cacheParams.AbsoluteExpiration,
            AbsoluteExpirationRelativeToNow = cacheParams.AbsoluteExpirationRelativeToNow
        });
    }

    public async Task Clear(string key)
    {
        await _cache.RemoveAsync(key);
    }

}