using Core;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using UnitTests.RepositoryLayerTests.ArrangeWeatherControllerUnitTests;

namespace UnitTests.RepositoryLayerTests;

public class WeatherRepositoryTests
{
    const int MAXIMUM_VALID_LATITUDE = 90;
    const int MINIMUM_VALID_LATITUDE = -90;
    const int MAXIMUM_VALID_LONGTITUDE = 180;
    const int MINIMUM_VALID_LONGTITUDE = -180;

    private MainForecastRepository _weatherForecastRepository;
    private static Random _random = new Random();
   
    private static IEnumerable<TestCaseData> ShouldThrowOutOfBondsExceptionTestCases
    {
        get
        {
            yield return new TestCaseData
            (
                _random.Next(MAXIMUM_VALID_LATITUDE, int.MaxValue) * -1 - _random.NextDouble(),
                _random.Next(MINIMUM_VALID_LONGTITUDE + 1, MAXIMUM_VALID_LONGTITUDE) - _random.NextDouble()
            )
            .SetName("Cases with latitude too low");
            yield return new TestCaseData
            (
                _random.Next(MINIMUM_VALID_LATITUDE + 1, MAXIMUM_VALID_LATITUDE) - _random.NextDouble(),
                _random.Next(MAXIMUM_VALID_LONGTITUDE, int.MaxValue) * -1 - _random.NextDouble()
             )
            .SetName("Cases with longtitude too low");
            yield return new TestCaseData
            (
                _random.Next(MAXIMUM_VALID_LATITUDE, int.MaxValue) - _random.NextDouble(),
                _random.Next(MINIMUM_VALID_LONGTITUDE + 1, MAXIMUM_VALID_LONGTITUDE) - _random.NextDouble()
            )
            .SetName("Cases with latitude too high");
            yield return new TestCaseData
            (
                _random.Next(MINIMUM_VALID_LATITUDE + 1, MAXIMUM_VALID_LATITUDE) - _random.NextDouble(),
                _random.Next(MAXIMUM_VALID_LONGTITUDE, int.MaxValue) - _random.NextDouble()
             )
            .SetName("Cases with longtitude too high");
        }
    }

    [SetUp]
    public void OneTimeSetUp()
    {
        var mockedOpenWeatherServiceClient = new Mock<IOpenWeatherServiceClient>();
        
        mockedOpenWeatherServiceClient.Setup(method =>
            method.GetTemperature(It.IsAny<double>(), It.IsAny<double>())).Returns(
                Task.FromResult(
                    Result<WeatherForecast>.Success(AssertWeatherForecast.GetWeatherForecastContainingTemperatureZero()
                )));

        var weatherForecastRepository = new MainForecastRepository(mockedOpenWeatherServiceClient.Object); //now dependant on IServiceProvider...
        _weatherForecastRepository = weatherForecastRepository;

    }


    [Test]
    [Repeat(25)]
    public async Task GetWeatherAsync_ShouldReturnTemperatureZero()
    {
        //Arrange
        double latitude = _random.Next(MINIMUM_VALID_LATITUDE + 1, MAXIMUM_VALID_LATITUDE) - _random.NextDouble();
        double longtitude = _random.Next(MINIMUM_VALID_LONGTITUDE + 1, MAXIMUM_VALID_LONGTITUDE) - _random.NextDouble();

        //Act
        var res = await _weatherForecastRepository.GetWeatherAsync(latitude, longtitude);

        //Assert
        Assert.That(res.Temp.Equals(0));
    }

    [Test]
    [Repeat(25)]
    //Arrange
    [TestCaseSource("ShouldThrowOutOfBondsExceptionTestCases")]
    [TestCase(MAXIMUM_VALID_LATITUDE + 0.000001, 0, TestName = "Maximum valid latidue border")]
    [TestCase(MINIMUM_VALID_LATITUDE - 0.000001, 0, TestName = "Maximum valid latidue border")]
    [TestCase(MAXIMUM_VALID_LONGTITUDE + 0.000001, 0, TestName = "Maximum valid latidue border")]
    [TestCase(MINIMUM_VALID_LONGTITUDE - 0.000001, 0, TestName = "Maximum valid latidue border")]
    public void GetWeatherAsync_ShouldThrowOutOfBondsException(double latitude, double longtitude)
    {
        //Act/Assert 
        Assert.ThrowsAsync<ArgumentException>(() => _weatherForecastRepository.GetWeatherAsync(latitude, longtitude));
    }



}
