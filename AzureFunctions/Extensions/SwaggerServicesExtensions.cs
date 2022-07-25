using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using AzureFunctions.SchemaFilters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Reflection;


namespace AzureFunctions.Extensions;
public static class SwaggerServicesExtensions
{

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwashBuckle(Assembly.GetExecutingAssembly(), swagDoc =>
        {
            swagDoc.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
            swagDoc.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "Swagger document",
                        Description = "Swagger test document",
                        Version = "v2"
                    }
                    };
            swagDoc.ConfigureSwaggerGen = config =>
            {
                config.SchemaFilter<EnumSchemaFilter>();
                config.UseInlineDefinitionsForEnums();
                config.AddSecurityDefinition("api_key", new OpenApiSecurityScheme()
                {
                    Description = "ApiKey",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "api_key"
                            }
                        },
                        new string[]{}
                    }
                });
            };
        });
        return services;
    }

}