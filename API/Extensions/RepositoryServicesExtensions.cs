using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;

namespace API.Extensions;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        return services;
    }

}
