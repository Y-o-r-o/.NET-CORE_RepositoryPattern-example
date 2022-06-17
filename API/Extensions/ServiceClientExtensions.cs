using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace API.Extensions;

public static class ServiceClientExtensions
{
    public static IServiceCollection AddServiceClientServices(this IServiceCollection services)
    {
        services.AddHttpClient<IOpenWeatherServiceClient, OpenWeatherServiceClient>(c =>
                {
                    c.BaseAddress = new Uri("https://api.openweathermap.org");
                });
        return services;
    }

}
