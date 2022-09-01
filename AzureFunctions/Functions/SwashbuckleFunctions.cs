using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctions.Functions;

internal class SwashbuckleFunctions
{
    private ISwashBuckleClient _swashBuckleClient;

    public SwashbuckleFunctions(ISwashBuckleClient swashBuckleClient)
    {
        _swashBuckleClient = swashBuckleClient;
    }

    [SwaggerIgnore]
    [Function("Swagger")]
    public Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/json")] HttpRequestData req)
    {
        return Task.FromResult(_swashBuckleClient.CreateSwaggerJsonDocumentResponse(req));
    }

    [SwaggerIgnore]
    [Function("SwaggerUi")]
    public Task<HttpResponseData> Run2(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/ui")] HttpRequestData req)
    {
        return Task.FromResult(_swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
    }
}