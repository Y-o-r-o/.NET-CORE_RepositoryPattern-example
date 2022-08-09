using Microsoft.Extensions.Caching.Distributed;

namespace RepositoryLayer.Databases.Cache;

public class CacheParams
{
    public string Key { get; }

    public DistributedCacheEntryOptions Options { get; set;}
}
