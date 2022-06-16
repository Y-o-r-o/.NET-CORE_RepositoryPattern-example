using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : BaseApiController
{

    private readonly IWeatherForecastRepository _weatherForecastService;

    public WeatherForecastController(IWeatherForecastRepository weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetTemperature()
    {
        return HandleResult(await _weatherForecastService.GetTemperature("54.687156","25.279651"));
    }
}
