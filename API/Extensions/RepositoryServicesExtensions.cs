using LOGIC.Services;
using LOGIC.Interfaces;

namespace API.Extensions;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();

        return services;
    }

}
