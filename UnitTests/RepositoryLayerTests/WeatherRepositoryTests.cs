using Core;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using UnitTests.RepositoryLayerTests.ArrangeWeatherRepositoryUnitTests;

namespace UnitTests.RepositoryLayerTests;

public class WeatherRepositoryTests
{

    private WeatherForecastRepository _weatherForecastRepository;

    [SetUp]
    public void SetUp()
    {
        var mockedOpenWeatherServiceClient = new Mock<IOpenWeatherServiceClient>();

        mockedOpenWeatherServiceClient.Setup(method =>
            method.GetTemperatureAsync(It.IsAny<double>(), It.IsAny<double>())).Returns(
                Task.FromResult(
                    Result<WeatherForecast>.Success(ArrangeWeatherForecast.GetWeatherForecastContainingTemperatureZero()
                )));

        var weatherForecastRepository = new WeatherForecastRepository(mockedOpenWeatherServiceClient.Object);
        _weatherForecastRepository = weatherForecastRepository;
    }

    [Test]
    //Arrange
    [TestCase(0, 0, TestName = "Middle of border")]
    [TestCase(ArrangeWeatherForecast.MAXIMUM_VALID_LATITUDE, 0, TestName = "Maximum valid latidue border")]
    [TestCase(ArrangeWeatherForecast.MINIMUM_VALID_LATITUDE, 0, TestName = "Maximum valid latidue border")]
    [TestCase(0, ArrangeWeatherForecast.MAXIMUM_VALID_LONGTITUDE, TestName = "Maximum valid latidue border")]
    [TestCase(0, ArrangeWeatherForecast.MINIMUM_VALID_LONGTITUDE, TestName = "Maximum valid latidue border")]
    public async Task GetWeatherAsync_ShouldReturnTemperatureZero(double latitude, double longtitude)
    {
        //Act
        var res = await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude);

        //Assert
        Assert.That(res.Main.Temp.Equals(0));
    }
}