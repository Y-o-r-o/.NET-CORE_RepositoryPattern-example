using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces;

public interface IWeatherServices
{
    public Task<MainForecastDTO> GetWeatherAsync(CordinatesDTO cordinates);

    public Task<MainForecastDTO> GetWeatherAsync(CityDTO city);
}