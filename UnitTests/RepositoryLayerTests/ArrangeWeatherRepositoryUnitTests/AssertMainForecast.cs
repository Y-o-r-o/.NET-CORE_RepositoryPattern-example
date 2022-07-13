using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherRepositoryUnitTests;

public class AssertMainForecast
{
    public static MainForecast GetForecastWithTemperatureZero()
    { return new MainForecast() { Temp = 0 }; }
}