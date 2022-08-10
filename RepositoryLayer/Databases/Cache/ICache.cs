namespace RepositoryLayer.Databases.Cache;

public interface ICache
{
    public Task<T?> Get<T>(string key) where T : class;

    public Task Set<T>(T? value, CacheParams options) where T : class;

    public Task Clear(string key);

}
