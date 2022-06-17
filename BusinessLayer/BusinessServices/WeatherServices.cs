using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using Core;
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

    public async Task<Result<MainForecastDTO>> GetWeather(string latitude, string longtitude)
    {
        if (string.IsNullOrWhiteSpace(latitude))
        {
            throw new ArgumentException(nameof(latitude));
        }
        if (string.IsNullOrWhiteSpace(longtitude))
        {
            throw new ArgumentException(nameof(longtitude));
        }

        var result = await _weatherForecastRepository.GetWeather(latitude, longtitude);

        if (result.IsSuccess)
        {
            var weather = MappingProfiles.Map(result.Value);
            return weather is null ?
                Result<MainForecastDTO>.Failure("Could not mapp: " + nameof(weather)) :
                Result<MainForecastDTO>.Success(weather);
        }

        return Result<MainForecastDTO>.Failure(result.Error);

    }

}