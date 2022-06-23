using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices : IWeatherServices
{
    // private readonly List<OrderItem> _orderItems;
    // public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    private IWeatherForecastRepository _weatherForecastRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<MainForecastDTO> GetWeatherAsync(string latitude, string longtitude)
    {
        if (string.IsNullOrWhiteSpace(latitude))
        {
            throw new ArgumentException(nameof(latitude));
        }
        if (string.IsNullOrWhiteSpace(longtitude))
        {
            throw new ArgumentException(nameof(longtitude));
        }

        var weather = MappingProfiles.Map(await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude));
        return weather;
    }

}