using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherRepositoryUnitTests;

public static class ArrangeWeatherForecast
{
    public const int MAXIMUM_VALID_LATITUDE = 90;
    public const int MINIMUM_VALID_LATITUDE = -90;
    public const int MAXIMUM_VALID_LONGTITUDE = 180;
    public const int MINIMUM_VALID_LONGTITUDE = -180;

    public static WeatherForecast GetWeatherForecastContainingTemperatureZero()
    {
        return new WeatherForecast() { Main = ArrangeMainForecast.GetForecastWithTemperatureZero() };
    }
}