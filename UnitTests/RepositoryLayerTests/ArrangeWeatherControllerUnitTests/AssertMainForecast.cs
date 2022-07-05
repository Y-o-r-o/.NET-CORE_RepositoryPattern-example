using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherControllerUnitTests;

public class AssertMainForecast
{
    public static MainForecast GetForecastWithTemperatureZero() { return new MainForecast() { Temp = 0 }; }
}
