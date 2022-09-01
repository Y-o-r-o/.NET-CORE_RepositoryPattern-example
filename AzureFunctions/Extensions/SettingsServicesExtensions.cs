using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceClientLayer;
using ServiceClientLayer.ServiceClients.GoogleMapsService;

namespace AzureFunctions.Extensions;

public static class SettingsServicesExtensions
{
    public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration config)
    {
        var openWeatherMapSettings = new OpenWeatherMapSettings()
        {
            ApiKey = Environment.GetEnvironmentVariable("OpenWeatherApiKey")
        };
        services.AddSingleton(openWeatherMapSettings);

        var googleMapsSettings = new GoogleMapsSettings()
        {
            ApiKey = Environment.GetEnvironmentVariable("GoogleMapsApiKey"),
            OutputFormat = Environment.GetEnvironmentVariable("GoogleMapsOutputFormat")
        };
        services.AddSingleton(googleMapsSettings);

        return services;
    }
}