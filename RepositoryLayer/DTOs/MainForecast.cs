using System.Text.Json.Serialization;

namespace RepositoryLayer.DTOs;
public class MainForecast
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
}
