using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices : IWeatherServices
{
    private IWeatherForecastRepository _weatherForecastRepository;
    private IGoogleMapsRepository _googleMapsRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository, IGoogleMapsRepository googleMapsRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _googleMapsRepository = googleMapsRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(ValidString latitude, ValidString longtitude)
    {
        return MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude));
    }

    public async Task<MainForecastDTO> GetWeatherAsync(CityDTO city)
    {
        var cordinates = await _googleMapsRepository.GetCordinates(city.ToString());
        return MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(cordinates.Lat.ToString(), cordinates.Lng.ToString()));
    }
}