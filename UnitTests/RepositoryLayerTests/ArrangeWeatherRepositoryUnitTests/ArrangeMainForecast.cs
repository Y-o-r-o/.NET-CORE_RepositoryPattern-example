using ServiceClientLayer.Models;

namespace UnitTests.RepositoryLayerTests.ArrangeWeatherRepositoryUnitTests;

public class ArrangeMainForecast
{
    public static MainForecast GetForecastWithTemperatureZero()
    { return new MainForecast() { Temp = 0 }; }
}