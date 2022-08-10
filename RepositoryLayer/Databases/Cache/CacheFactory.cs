namespace RepositoryLayer.Databases.Cache;

public class CacheFactory
{
    private readonly IServiceProvider serviceProvider;

    public CacheFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICache GetCacheService(CachingService cachingService)
    {
        //TO DO: ElseIfs/Swichcases violates open closed principle.
        
        if (cachingService.Equals(CachingService.InMemory))
            return (ICache)serviceProvider.GetService(typeof(MemoryCache));

        return (ICache)serviceProvider.GetService(typeof(DistributedCache));
    }
}
