using System.Text.Json.Serialization;

namespace RepositoryLayer.DTOs;

public class WeatherForecast
{
    [JsonPropertyName("main")]
    public MainForecast Main { get; set; }
}
