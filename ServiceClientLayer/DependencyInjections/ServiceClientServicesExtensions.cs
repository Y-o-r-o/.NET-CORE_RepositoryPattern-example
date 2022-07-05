using Microsoft.Extensions.DependencyInjection;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace ServiceClientLayer.DependencyInjections;
public static class ServiceClientServicesExtensions
{
    public static IServiceCollection AddServiceClientServices(this IServiceCollection services)
    {
        services.AddHttpClient<IOpenWeatherServiceClient, OpenWeatherServiceClient>(c =>
        {
            c.BaseAddress = new Uri("https://api.openweathermap.org");
        });
        services.AddHttpClient<IGoogleMapsServiceClient, GoogleMapsServiceClient>(c =>
        {
            c.BaseAddress = new Uri("https://maps.googleapis.com");
        });
        return services;
    }

}
