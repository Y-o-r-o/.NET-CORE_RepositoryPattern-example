using Microsoft.AspNetCore.Mvc;

namespace AzureFunctions.Functions.Base;

public class BaseFunction
{
    protected ActionResult HandleResult<T>(T result)
    {
        if (result == null) return new NotFoundResult();
        return new OkObjectResult(result);
    }
}