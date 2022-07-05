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
    /// <param name="latitude" example="54.687156">The cordinates of location.</param>
    /// <param name="longtitude" example="25.279651">The cordinates of location.</param>
    /// <returns>got temperature in celsius.</returns>
    [HttpGet("GetTemperature/Cordinates")]
    [ProducesResponseType(typeof(MainForecastDTO), 200)]
    [ProducesResponseType(typeof(AppException), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTemperature([Range(typeof(double), "-90", "90")]double latitude, [Range(typeof(double), "-180", "180")] double longtitude)
    {
        return HandleResult(await _weatherServices.GetWeatherAsync(latitude, longtitude));
    }

    /// <summary>Gets a temperature in celsius by city name.</summary>
    /// <param name="city">The city.</param>
    /// <returns>got temperature in celsius.</returns>
    [HttpPost("GetTemperature/City")]
    [ProducesResponseType(typeof(MainForecastDTO), 200)]
    [ProducesResponseType(typeof(AppException), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTemperature(/*[Required]CityDTO city*/)
    {
        return HandleResult(await _weatherServices.GetWeatherAsync(CityDTO.Vilnius));
    }

}