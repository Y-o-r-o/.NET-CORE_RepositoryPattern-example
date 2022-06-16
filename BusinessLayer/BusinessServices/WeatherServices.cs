using BusinessLayer.DTOs;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class WeatherServices
{
    // private readonly List<OrderItem> _orderItems;
    // public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    private IWeatherForecastRepository _weatherForecastRepository;

    public WeatherServices(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public MainForecastDTO GetWeather(string latitude, string longtitude)
    {
        throw new NotImplementedException();
    }

}