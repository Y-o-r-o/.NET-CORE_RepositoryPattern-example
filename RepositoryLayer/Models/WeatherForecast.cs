namespace RepositoryLayer.Models;

public class WeatherForecast
{
    public MainForecast MainForecast { get; set; }
}

public class MainForecast
{
    public double Temp { get; set; }
}
