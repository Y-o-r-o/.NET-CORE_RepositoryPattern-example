using Core;
using RepositoryLayer.Mappers;


namespace RepositoryLayer.Repositories.Base;

internal abstract class ServiceClientRepositoryBase<TEntity> where TEntity : class, new()
{

    protected ServiceClientRepositoryBase() { }

    public virtual async Task<TEntity?> GetAsync<TServiceClientEntity, TParam>(Func<TParam, Task<Result<TServiceClientEntity>>> ServiceClientGetAsync, TParam param)
         where TServiceClientEntity : class, new()
        => ProcessGetResponseAsync<TServiceClientEntity>(await ServiceClientGetAsync(param));

    public virtual async Task<TEntity?> GetAsync<TServiceClientEntity, TParam, TParam2>(Func<TParam, TParam2, Task<Result<TServiceClientEntity>>> ServiceClientGetAsync, TParam param, TParam2 param2)
         where TServiceClientEntity : class, new()
        => ProcessGetResponseAsync<TServiceClientEntity>(await ServiceClientGetAsync(param, param2));


    private TEntity? ProcessGetResponseAsync<TServiceClientEntity>(Result<TServiceClientEntity> response)
        where TServiceClientEntity : class, new()
    {
        TEntity? entity = null;

        if (response.IsSuccess)
        {

            entity = MappingProfiles.TryMap<TServiceClientEntity, TEntity>(response.Value);
        }

        return entity;
    }
}