using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
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
        var location = MappingProfiles.Map(await _googleMapsRepository.GetGeocodeByCityName(city.ToString()));
        return MappingProfiles.Map((await _weatherForecastRepository.GetWeatherAsync(location.Lat, location.Lng)).Main);
    }
}