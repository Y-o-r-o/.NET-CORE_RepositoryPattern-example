using Core;
using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Mappers;

namespace RepositoryLayer.Repositories.Base;

internal abstract class ServiceClientRepositoryBase<TEntity> : RepositoryBase
    where TEntity : class, new()
{
    protected ServiceClientRepositoryBase(CacheFactory cacheFactory) : base(cacheFactory) { }

    public virtual async Task<TEntity?> GetAsync<TServiceClientEntity>(Func<Task<Result<TServiceClientEntity>>> ServiceClientGetAsync, CacheParams? cacheParams = null)
         where TServiceClientEntity : class, new()
        => (cacheParams is null) ? ProcessGetResponseAsync(await ServiceClientGetAsync())
            : ProcessGetResponseAsync(await HandleCaching(ServiceClientGetAsync, cacheParams));


    private static TEntity? ProcessGetResponseAsync<TServiceClientEntity>(Result<TServiceClientEntity>? response)
         where TServiceClientEntity : class, new()
    {
        if(response is null) throw new Exception("Result cant be null.");
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