using BusinessLayer.BusinessServices;
using BusinessLayer.DTOs;
using BusinessLayer.Enums;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

namespace UnitTests.BusinessLayerTests;

[TestFixture]
public class WeatherServicesTests
{
    private const double MAXIMUM_VALID_LATITUDE = 90;
    private const double MINIMUM_VALID_LATITUDE = -90;
    private const double MAXIMUM_VALID_LONGTITUDE = 180;
    private const double MINIMUM_VALID_LONGTITUDE = -180;

    private MockRepository mockRepository;

    private Mock<IWeatherForecastRepository> _mockWeatherForecastRepository;
    private Mock<IGeocodeRepository> _mockGeocodeRepository;

    [SetUp]
    public void SetUp()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);

        _mockWeatherForecastRepository = mockRepository.Create<IWeatherForecastRepository>();
        _mockGeocodeRepository = mockRepository.Create<IGeocodeRepository>();
    }

    private WeatherServices InitializeTestingObj()
    {
        return new WeatherServices(
            _mockWeatherForecastRepository.Object,
            _mockGeocodeRepository.Object
        );
    }

    [Test]
    public void GetWeatherAsync_GiveNullParam_ThrowsNullReferenceException()
    {
        // Arrange
        _mockWeatherForecastRepository.Setup(m => m
            .GetWeatherAsync(It.IsAny<double>(), It.IsAny<double>()))
            .ReturnsAsync(new WeatherForecast());
        var weatherServices = InitializeTestingObj();
        CordinatesDTO cordinates = null;

        // Act
        var action = new Func<Task<MainForecastDTO>>(() => weatherServices.GetWeatherAsync(cordinates));

        // Assert
        Assert.ThrowsAsync<NullReferenceException>(() => action.Invoke());
    }

    [Test]
    [TestCase(0, 0, TestName = "Middle of border")]
    [TestCase(MAXIMUM_VALID_LATITUDE, 0, TestName = "Maximum valid latidue border")]
    [TestCase(MINIMUM_VALID_LATITUDE, 0, TestName = "Maximum valid latidue border")]
    [TestCase(0, MAXIMUM_VALID_LONGTITUDE, TestName = "Maximum valid latidue border")]
    [TestCase(0, MINIMUM_VALID_LONGTITUDE, TestName = "Maximum valid latidue border")]
    public async Task GetWeatherAsync_GiveValidCordinateParam_ReturnsObject(double latitude, double longtitude)
    {
        // Arrange
        _mockWeatherForecastRepository.Setup(m => m
            .GetWeatherAsync(It.IsAny<double>(), It.IsAny<double>()))
            .Returns(Task.FromResult(
                new WeatherForecast()));
        var weatherServices = InitializeTestingObj();
        CordinatesDTO cordinates = new() { Latitude = latitude, Longitude = longtitude };

        // Act
        var result = await weatherServices.GetWeatherAsync(cordinates);

        // Assert
        Assert.NotNull(result);
    }

    [Test]
    public async Task GetWeatherAsync_GiveCityNoneParam_ReturnsNull()
    {
        // Arrange
        _mockWeatherForecastRepository.Setup(m => m
            .GetWeatherAsync(It.IsAny<double>(), It.IsAny<double>()))
            .Returns(Task.FromResult(
                new WeatherForecast()));
        _mockGeocodeRepository.Setup(m => m
            .GetGeocodeByCityNameAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(
                ArrangeGeocode.Results()));
        var weatherServices = InitializeTestingObj();
        City city = City.None;

        // Act
        var result = await weatherServices.GetWeatherAsync(city);

        // Assert
        Assert.Null(result);
    }

    [Test]
    [TestCase("Vilnius", TestName = "Get Vilnius weather")]
    [TestCase("Kaunas", TestName = "Get Kaunas weather")]
    [TestCase("Klaipeda", TestName = "Get Klaipeda weather")]
    public async Task GetWeatherAsync_GiveValidCityParam_ReturnsObject(string city)
    {
        // Arrange
        _mockWeatherForecastRepository.Setup(m => m
            .GetWeatherAsync(It.IsAny<double>(), It.IsAny<double>()))
            .Returns(Task.FromResult(
                new WeatherForecast()));
        _mockGeocodeRepository.Setup(m => m
            .GetGeocodeByCityNameAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(
                ArrangeGeocode.Results()));
        var weatherServices = InitializeTestingObj();
        City cityEnum = (City)Enum.Parse(typeof(City), city);

        // Act
        var result = await weatherServices.GetWeatherAsync(cityEnum);

        // Assert
        Assert.NotNull(result);
    }

}