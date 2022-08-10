using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace RepositoryLayer.Databases.Cache;

public class MemoryCache : ICache
{
    private readonly IMemoryCache _cache;

    public MemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> Get<T>(string key)
        where T : class
    {
        if (_cache.TryGetValue(key, out T respone)) return respone;
        return null;
    }

    public async Task Set<T>(T? value, CacheParams cacheParams)
        where T : class
    {
        _cache.Set(cacheParams.Key, value, new MemoryCacheEntryOptions()
        {
            SlidingExpiration = cacheParams.SlidingExpiration,
            AbsoluteExpiration = cacheParams.AbsoluteExpiration,
            AbsoluteExpirationRelativeToNow = cacheParams.AbsoluteExpirationRelativeToNow
        });
    }

    public async Task Clear(string key)
    {
        _cache.Remove(key);
    }
}