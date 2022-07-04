using Core;
using Moq;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace UnitTests.RepositoryLayerTests;

public class WeatherRepositoryTests
{
    const int MAXIMUM_VALID_LATITUDE = 90;
    const int MINIMUM_VALID_LATITUDE = -90;
    const int MAXIMUM_VALID_LONGTITUDE = 180;
    const int MINIMUM_VALID_LONGTITUDE = -180;

    private WeatherForecastRepository _weatherForecastRepository;


    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var mockedOpenWeatherServiceClient = new Mock<IOpenWeatherServiceClient>();
        mockedOpenWeatherServiceClient.Setup(method =>
            method.GetTemperature(It.IsAny<string>(), It.IsAny<string>())).Returns(
                Task.FromResult(
                    Result<WeatherForecast>.Success(new WeatherForecast
                    {
                        Main = new MainForecast()
                        {
                            Temp = 0
                        }
                    })));

        var weatherForecastRepository = new WeatherForecastRepository(mockedOpenWeatherServiceClient.Object);
        _weatherForecastRepository = weatherForecastRepository;
    }

    [Test]
    [Repeat(25)]
    public void ShouldReturnTemperatureZero()
    {
        //Arrange
        var rand = new Random();

        string latitude = (rand.Next(MINIMUM_VALID_LATITUDE, MAXIMUM_VALID_LATITUDE-1) + rand.NextDouble()).ToString();
        string longtitude = (rand.Next(MINIMUM_VALID_LONGTITUDE, MAXIMUM_VALID_LONGTITUDE-1) + rand.NextDouble()).ToString();

        //Act
        var res = Task.FromResult(_weatherForecastRepository.GetWeatherAsync(latitude, longtitude)).Result;


        //Assert
        Assert.AreEqual(0, res.Result.Temp);
    }
}