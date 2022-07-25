using BusinessLayer.BusinessServices.DependencyInjections;
using System.Text.Json.Serialization;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureSettings(config);
        services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer()
                .AddSwaggerExtensions();

        services.AddBusinessServices(config);

        return services;
    }
}