using Core;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using UnitTests.RepositoryLayerTests.ArrangeWeatherControllerUnitTests;

namespace UnitTests.RepositoryLayerTests;

public class WeatherRepositoryTests
{
    private WeatherForecastRepository _weatherForecastRepository;
    private static Random _random = new Random();

    [SetUp]
    public void SetUp()
    {
        var mockedOpenWeatherServiceClient = new Mock<IOpenWeatherServiceClient>();
        
        mockedOpenWeatherServiceClient.Setup(method =>
            method.GetTemperature(It.IsAny<double>(), It.IsAny<double>())).Returns(
                Task.FromResult(
                    Result<WeatherForecast>.Success(AssertWeatherForecast.GetWeatherForecastContainingTemperatureZero()
                )));

        var weatherForecastRepository = new WeatherForecastRepository(mockedOpenWeatherServiceClient.Object); //now dependant on IServiceProvider...
        _weatherForecastRepository = weatherForecastRepository;

    }

}
