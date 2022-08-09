using Core;
using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Mappers;

namespace RepositoryLayer.Repositories.Base;

internal abstract class ServiceClientRepositoryBase<TEntity> : RepositoryBase
    where TEntity : class, new()
{
    protected ServiceClientRepositoryBase(Cache cache) : base(cache) { }

    public virtual async Task<TEntity?> GetAsync<TServiceClientEntity>(Func<Task<Result<TServiceClientEntity>>> ServiceClientGetAsync, CacheParams? cacheParams = null)
         where TServiceClientEntity : class, new()
    {
        if (cacheParams is null)
        {
            return ProcessGetResponseAsync(await ServiceClientGetAsync());
        }
        return ProcessGetResponseAsync(await HandleCache(ServiceClientGetAsync, cacheParams));
    }

    private TEntity? ProcessGetResponseAsync<TServiceClientEntity>(Result<TServiceClientEntity> response)
         where TServiceClientEntity : class, new()
    {
        if (response.Value is null) throw new Exception("Couldn't get response value.");

        TEntity? entity = null;

        if (response.IsSuccess)
        {
            entity = MappingProfiles.TryMap<TServiceClientEntity, TEntity>(response.Value);
        }
        
        //TO DO: If respone is failure then maybe log failure?
        
        return entity;
    }
}