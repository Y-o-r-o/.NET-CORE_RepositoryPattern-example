using BusinessLayer.Helpers;
using Core;
using System.Diagnostics;
using System.Net;

namespace BusinessLayer.BusinessServices.Base;

[StackTraceHidden]
internal class RepositoryBusinessBase
{
    protected virtual async Task<TEnumerable> GetAllAsync<TEnumerable>(Func<Task<TEnumerable>> RepositoryGetAsync, string? customExceptionMessage = null)
        => ProcessGetResponseAsync(await RepositoryGetAsync(), customExceptionMessage);

    protected virtual async Task<TModel> GetAsync<TModel, TParam>(Func<TParam, Task<TModel?>> RepositoryGetAsync, TParam param, string? customExceptionMessage = null)
        where TModel : new()
        => ProcessGetResponseAsync(await RepositoryGetAsync(param), customExceptionMessage);

    protected virtual async Task<TModel> GetAsync<TModel, TParam, TParam2>(Func<TParam, TParam2, Task<TModel?>> RepositoryGetAsync, TParam param, TParam2 param2, string? customExceptionMessage = null)
                where TModel : new()
        => ProcessGetResponseAsync(await RepositoryGetAsync(param, param2), customExceptionMessage);


    private TModel ProcessGetResponseAsync<TModel>(TModel? result, string? customExceptionMessage)
    {
        if (result is null) throw new HttpResponseException(HttpStatusCode.NotFound, customExceptionMessage);
        Validator.CheckIfAllObjectNonNullablePropertiesIsNotNull(result);
        return result;
    }
}
