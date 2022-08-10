using RepositoryLayer.Databases.Cache;

namespace RepositoryLayer.Repositories.Base;

internal abstract class RepositoryBase
{

    private readonly CacheFactory _cacheFactory;

    protected RepositoryBase(CacheFactory cacheFactory)
    {
        _cacheFactory = cacheFactory;
    }

    public async Task<TResponse?> HandleCaching<TResponse>(Func<Task<TResponse?>> GetAsync, CacheParams? cacheParams)
        where TResponse : class
    {
        var cache = _cacheFactory.GetCacheService(cacheParams.CachingService); 

        if (cacheParams is null) return await GetAsync();

        var response = await cache.Get<TResponse>(cacheParams.Key);

        if(response is null)
        {
            response = await GetAsync();
            await cache.Set(response, cacheParams);
        }

        return response;
    }

}
