using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherRepositoryUnitTests;

public static class AssertWeatherForecast
{
    private const int MAXIMUM_VALID_LATITUDE = 90;
    private const int MINIMUM_VALID_LATITUDE = -90;
    private const int MAXIMUM_VALID_LONGTITUDE = 180;
    private const int MINIMUM_VALID_LONGTITUDE = -180;

    public static WeatherForecast GetWeatherForecastContainingTemperatureZero()
    {
        return new WeatherForecast() { Main = AssertMainForecast.GetForecastWithTemperatureZero() };
    }
}