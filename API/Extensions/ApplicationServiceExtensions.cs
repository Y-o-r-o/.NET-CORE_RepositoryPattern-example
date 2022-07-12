using API.Controllers;
using BusinessLayer.BusinessServices.DependencyInjections;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Repositories.DependencyInjections;
using ServiceClientLayer.DependencyInjections;
using Swashbuckle.AspNetCore.Filters;
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


        services.AddServiceClientServices()
                .AddRepositoryServices(config)
                .AddBusinessServices();

        return services;
    }
}