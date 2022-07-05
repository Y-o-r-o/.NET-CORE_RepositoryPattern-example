using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherControllerUnitTests;

public static class AssertWeatherForecast
{
    public static WeatherForecast GetWeatherForecastContainingTemperatureZero()
    {
        return new WeatherForecast() { Main = AssertMainForecast.GetForecastWithTemperatureZero() };
    }
}
