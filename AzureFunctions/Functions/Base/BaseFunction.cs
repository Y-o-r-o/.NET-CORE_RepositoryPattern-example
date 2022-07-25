using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctions.Functions.Base;

public class BaseFunction
{
    protected ActionResult HandleResult<T>(T result)
    {
        if (result == null) return new NotFoundResult();
        return new OkObjectResult(result);
    }

    protected ActionResult AuthorizeAndHandleResult<T>(HttpRequestData req, T result)
    {
        var ApiKeyHeader = req.Headers.FirstOrDefault(h => h.Key.Equals("Authorization"));
        if (ApiKeyHeader.Value is null) return new UnauthorizedResult();
        //TO DO: Implement some key validation...
        return HandleResult(result);
    }
}