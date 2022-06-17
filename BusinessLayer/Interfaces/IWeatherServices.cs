using BusinessLayer.DTOs;
using Core;

namespace BusinessLayer.Interfaces;

public interface IWeatherServices
{
    public Task<MainForecastDTO> GetWeather(string latitude, string longtitude);
}
