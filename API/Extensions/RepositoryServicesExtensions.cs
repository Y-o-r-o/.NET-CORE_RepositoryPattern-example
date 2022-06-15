using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;

namespace API.Extensions;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(c =>
        {
            c.BaseAddress = new Uri("https://api.openweathermap.org");        
        });

        return services;
    }

}
