using BusinessLayer.DTOs;
using Core;

namespace BusinessLayer.Interfaces;

public interface IWeatherServices
{
    public Task<MainForecastDTO> GetWeatherAsync(ValidString latitude, ValidString longtitude);
}
