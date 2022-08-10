namespace RepositoryLayer.Databases.Cache;

public class CacheFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CacheFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICache GetCacheService(CachingService cachingService)
    {
        //TO DO: ElseIfs/Swichcases violates open closed principle.
        if (cachingService.Equals(CachingService.InMemory))
            return (ICache)_serviceProvider.GetService(typeof(MemoryCache));

        return (ICache)_serviceProvider.GetService(typeof(DistributedCache));
    }
}
