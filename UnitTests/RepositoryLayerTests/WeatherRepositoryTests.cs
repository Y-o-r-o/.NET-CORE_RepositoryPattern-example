using Core;
using Moq;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace UnitTests.RepositoryLayerTests;

public class WeatherRepositoryTests
{

    private WeatherForecastRepository _weatherForecastRepository;

    [SetUp]
    public void Setup()
    {
        var mockedOpenWeatherServiceClient = new Mock<IOpenWeatherServiceClient>();
        mockedOpenWeatherServiceClient.Setup(method =>
            method.GetTemperature("", "")).Returns(
                Task.FromResult(
                    Result<WeatherForecast>.Success(new WeatherForecast
                    {
                        Main = new MainForecast()
                        {
                            Temp = 10
                        }
                    })));
        var weatherForecastRepository = new WeatherForecastRepository(mockedOpenWeatherServiceClient.Object);
        _weatherForecastRepository = weatherForecastRepository;
    }

    [Test]
    public void GetWeatherAsyncTest()
    {
        var res = Task.FromResult(_weatherForecastRepository.GetWeatherAsync("", "")).Result;

        Assert.AreEqual(10, res.Result.Temp);
    }
}