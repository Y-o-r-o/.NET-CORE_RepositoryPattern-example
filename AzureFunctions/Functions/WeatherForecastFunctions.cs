using AzureFunctions.Extensions.Swashbuckle.Attribute;
using AzureFunctions.Functions.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using Core.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctions.Functions;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class WeatherForecastFunctions : BaseFunction
{
    private readonly IWeatherServices _weatherServices;

    public WeatherForecastFunctions(IWeatherServices weatherServices)
    {
        _weatherServices = weatherServices;
    }

    /// <summary>Gets a temperature in celsius by cordinates.</summary>
    /// <returns>got temperature in celsius.</returns>
    [Function("GetTemperatureFromCordinates")]
    [ProducesResponseType(typeof(ActionResult<MainForecastDTO>), 200)]
    [QueryStringParameter("City", "The city to get temperature from", "Vilnius", DataType = typeof(CordinatesDTO), Required = true)]
    public async Task<IActionResult> GetTemperatureFromCordinatesAsync(
        [HttpTrigger("get", Route = "WeatherForecast/FromCordinates")] HttpRequestData req)
    {
        var cordinates = await req.Body.DeserializeAsync<CordinatesDTO>();

        return HandleResult(await _weatherServices.GetWeatherAsync(cordinates));
    }

    /// <summary>Gets a temperature in celsius by city name.</summary>
    /// <returns>got temperature in celsius.</returns>
    [ProducesResponseType(typeof(ActionResult<MainForecastDTO>), 200)]
    [Function("GetTemperatureFromCity")]
    [QueryStringParameter("City", "The city to get temperature from", "Vilnius", DataType = typeof(City), Required = true)]
    public async Task<IActionResult> GetTemperatureFromCityAsync(
        [HttpTrigger("get", Route = "WeatherForecast/FromCity")] HttpRequestData req)
    {
        var queryValue = req.QueryDictionary()["City"];
        var city = (City)Enum.Parse(typeof(City), queryValue);

        return HandleResult(await _weatherServices.GetWeatherAsync(city));
    }
}