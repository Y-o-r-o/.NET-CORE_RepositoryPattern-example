using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherControllerUnitTests;

public static class AssertWeatherForecast
{
    const int MAXIMUM_VALID_LATITUDE = 90;
    const int MINIMUM_VALID_LATITUDE = -90;
    const int MAXIMUM_VALID_LONGTITUDE = 180;
    const int MINIMUM_VALID_LONGTITUDE = -180;

    public static WeatherForecast GetWeatherForecastContainingTemperatureZero()
    {
        return new WeatherForecast() { Main = AssertMainForecast.GetForecastWithTemperatureZero() };
    }
}
