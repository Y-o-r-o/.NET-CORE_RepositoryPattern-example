using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices : IWeatherServices
{
    private IWeatherForecastRepository _weatherForecastRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(ValidString latitude, ValidString longtitude)
    {
        return MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude));
    }

}