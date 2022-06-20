using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : BaseApiController
{

    private readonly IWeatherServices _weatherServices;

    public WeatherForecastController(IWeatherServices weatherServices)
    {
        _weatherServices = weatherServices;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetTemperature()
    {
        return HandleResult(await _weatherServices.GetWeather("54.687156","25.279651"));
    }

}
