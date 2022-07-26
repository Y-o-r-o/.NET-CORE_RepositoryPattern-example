using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceClientLayer;
using ServiceClientLayer.ServiceClients.GoogleMapsService;

namespace AzureFunctions.Extensions;

public static class SettingsServicesExtensions
{
    public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration config)
    {
        var openWeatherMapSettings = new OpenWeatherMapSettings();
        config.Bind(nameof(OpenWeatherMapSettings), openWeatherMapSettings);
        services.AddSingleton(openWeatherMapSettings);

        var googleMapsSettings = new GoogleMapsSettings();
        config.Bind(nameof(GoogleMapsSettings), googleMapsSettings);
        services.AddSingleton(googleMapsSettings);

        return services;
    }
}