using Core;
using RepositoryLayer.Mappers;

namespace RepositoryLayer.Repositories.Base;

internal abstract class ServiceClientRepositoryBase<TEntity> where TEntity : class, new()
{
    protected ServiceClientRepositoryBase()    { }

    public virtual async Task<TEntity?> GetAsync<TServiceClientEntity>(Func<Task<Result<TServiceClientEntity>>> ServiceClientGetAsync)
         where TServiceClientEntity : class, new()
        => ProcessGetResponseAsync(await ServiceClientGetAsync());


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