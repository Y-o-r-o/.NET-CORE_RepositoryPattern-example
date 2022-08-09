using Microsoft.Extensions.Caching.Distributed;
using RepositoryLayer.Databases.Cache;

namespace RepositoryLayer.Repositories.Base;

internal abstract class RepositoryBase
{

    private readonly Cache _cache;

    protected RepositoryBase(Cache cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> HandleCache<TResponse>(Func<Task<TResponse>> GetAsync, CacheParams cacheParams)
        where TResponse : class
    {
        var response = await _cache.Get<TResponse>(cacheParams.Key);

        if(response is null)
        {
            response = await GetAsync();
            await _cache.Set(cacheParams.Key, response, new DistributedCacheEntryOptions
            (
                //TO DO..
            ));
        }

        return response;
    }

}
