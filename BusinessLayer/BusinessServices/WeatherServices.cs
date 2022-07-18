using BusinessLayer.BusinessServices.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;

namespace BusinessLayer.BusinessServices;

internal class WeatherServices : RepositoryBusinessBase, IWeatherServices
{
    private IWeatherForecastRepository _weatherForecastRepository;
    private IGeocodeRepository _googleMapsRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository, IGeocodeRepository googleMapsRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _googleMapsRepository = googleMapsRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(CordinatesDTO cordinates)
    {
        var weatherForecast = await GetAsync(_weatherForecastRepository.GetWeatherAsync, cordinates.Latitude, cordinates.Longitude);
        return GetWeather(weatherForecast);
    }

    public async Task<MainForecastDTO> GetWeatherAsync(City city)
    {
        if (city.Equals(City.None)) return null;
        var location = MappingProfiles.Map(await GetAsync(_googleMapsRepository.GetGeocodeByCityNameAsync, city.ToString()));

        var weatherForecast = await GetAsync(_weatherForecastRepository.GetWeatherAsync, 56.5, 56.5);
        return GetWeather(weatherForecast);
    }

    public MainForecastDTO GetWeather(WeatherForecast weatherForecast)
        => MappingProfiles.Map(weatherForecast.Main);
}