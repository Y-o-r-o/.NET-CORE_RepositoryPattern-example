using BusinessLayer.DTOs;
using BusinessLayer.Enums;

namespace BusinessLayer.Interfaces;

public interface IWeatherServices
{
    public Task<MainForecastDTO> GetWeatherAsync(CordinatesDTO cordinates);

    public Task<MainForecastDTO> GetWeatherAsync(City city);
}