using BusinessLayer.BusinessServices.DependencyInjections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctions.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureSettings(config);

        services.AddHttpContextAccessor();
        services.AddSwaggerServices();

        services.AddBusinessServices(config);

        return services;
    }
}