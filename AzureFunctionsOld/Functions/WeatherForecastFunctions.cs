using AzureFunctions.Functions.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace AzureFunctions.Functions;

public class WeatherForecastFunctions : BaseFunction
{
    private readonly IWeatherServices _weatherServices;

    public WeatherForecastFunctions(IWeatherServices weatherServices)
    {
        _weatherServices = weatherServices;
    }

    [FunctionName("GetTemperatureFromCordinates")]
    [OpenApiOperation(operationId: "GetTemperatureFromCordinates", tags: new[] { "name" })]
    [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CordinatesDTO), Description = "Cordinates", Required = true)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
    public async Task<IActionResult> GetTemperatureFromCordinatesAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    {
        var cordinates = await req.Body.DeserializeAsync<CordinatesDTO>();

        return HandleResult(await _weatherServices.GetWeatherAsync(cordinates));
    }

    [FunctionName("GetTemperatureFromCity")]
    [OpenApiOperation(operationId: "GetTemperatureFromCity", tags: new[] { "name2" })]
    [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
    [OpenApiParameter(name: "city", In = ParameterLocation.Query, Required = true, Type = typeof(City), Description = "City")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
    public async Task<IActionResult> GetTemperatureFromCityAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    {
        var city = await req.Body.DeserializeAsync<City>();

        return HandleResult(await _weatherServices.GetWeatherAsync(city));
    }
}