using Microsoft.Extensions.Caching.Distributed;

namespace RepositoryLayer.Databases.Cache;

public class CacheParams
{
    public CacheParams(string key)
    {
        Key = key;
    }

    public string Key { get; }

    public CachingService CachingService { get; set; } = CachingService.InMemory;

    public DateTimeOffset? AbsoluteExpiration { get; set; }

    public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }

    public TimeSpan? SlidingExpiration { get; set; }
}

public enum CachingService
{
    InMemory,
    Redis
}