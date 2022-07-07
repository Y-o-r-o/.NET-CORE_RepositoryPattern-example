using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

    /// <summary>Gets a temperature in celsius from cordinates.</summary>
    /// <returns>got temperature in celsius.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(MainForecastDTO), 200)]
    [ProducesResponseType(typeof(AppException), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTemperature([FromBody]CordinatesDTO cordinates)
    {
        return HandleResult(await _weatherServices.GetWeatherAsync(cordinates));
    }

    /// <summary>Gets a temperature in celsius by city name.</summary>
    /// <param name="city">The city.</param>
    /// <returns>got temperature in celsius.</returns>
    [HttpGet("{city}")]
    [ProducesResponseType(typeof(MainForecastDTO), 200)]
    [ProducesResponseType(typeof(AppException), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTemperature(CityDTO city)
    {
        return HandleResult(await _weatherServices.GetWeatherAsync(city));
    }

}