using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices : IWeatherServices
{
    private IWeatherForecastRepository _weatherForecastRepository;
    private IGeocodeRepository _googleMapsRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository, IGeocodeRepository googleMapsRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _googleMapsRepository = googleMapsRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(double latitude, double longtitude)
        => MappingProfiles.Map((await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude)).Main);

    public async Task<MainForecastDTO> GetWeatherAsync(CityDTO city)
    {
        var goecode = await _googleMapsRepository.GetGeocodeByCityName("Vilnius"); //city.ToString()
        var cordinates = goecode.Results[0].Geometry.Location;
        return MappingProfiles.Map((await _weatherForecastRepository.GetWeatherAsync(cordinates.Lat, cordinates.Lng)).Main);
    }
}