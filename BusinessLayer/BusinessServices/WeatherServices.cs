using BusinessLayer.BusinessServices.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

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


    public async Task<MainForecastDTO> GetWeatherAsync(CityDTO city)
    {
        var location = MappingProfiles.Map(await GetAsync(_googleMapsRepository.GetGeocodeByCityNameAsync, city.ToString()));

        var weatherForecast = await GetAsync(_weatherForecastRepository.GetWeatherAsync, location.Lat, location.Lng);
        return GetWeather(weatherForecast);
    }

    public MainForecastDTO GetWeather(WeatherForecast weatherForecast)
        => MappingProfiles.Map(weatherForecast.Main);


}
