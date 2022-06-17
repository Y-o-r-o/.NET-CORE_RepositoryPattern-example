using BusinessLayer.BusinessServices;
using BusinessLayer.Interfaces;
using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;

namespace API.Extensions;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherServices, WeatherServices>();
        return services;
    }

}
