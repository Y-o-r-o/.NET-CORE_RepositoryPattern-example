using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;

namespace API.Extensions;

public static class ServiceClientExtensions
{
    public static IServiceCollection AddServiceClientServices(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherForecastRepository, WeatherForecastRepository>(c =>
        {
            c.BaseAddress = new Uri("https://api.openweathermap.org");        
        });

        return services;
    }

}
