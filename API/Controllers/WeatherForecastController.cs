using BusinessLayer.DTOs;
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

    [HttpGet("Get")]
    public async Task<IActionResult> GetTemperature(CordinatesDTO cordinates)
    {
        return HandleResult(await _weatherServices.GetWeatherAsync(cordinates.Latitude, cordinates.Longitude));
    }

}
