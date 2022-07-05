using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices : IWeatherServices
{
    private IMainForecastRepository _weatherForecastRepository;
    private ILocationRepository _googleMapsRepository;

    public WeatherServices(IMainForecastRepository weatherForecastRepository, ILocationRepository googleMapsRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _googleMapsRepository = googleMapsRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(double latitude, double longtitude)
    {
        return MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude));
    }

    public async Task<MainForecastDTO> GetWeatherAsync(CityDTO city)
    {
        var cordinates = await _googleMapsRepository.GetLocationByCityName("Vilnius"); //city.ToString()
        return MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(cordinates.Lat, cordinates.Lng));
    }
}