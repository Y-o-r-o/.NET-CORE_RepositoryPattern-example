using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces;

public interface IWeatherServices
{
    public Task<MainForecastDTO> GetWeatherAsync(string latitude, string longtitude);
}
