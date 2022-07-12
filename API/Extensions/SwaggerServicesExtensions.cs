using API.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace API.Extensions;


public static class SwaggerServicesExtensions
{
    public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "OrionTraining API - V1",
                    Version = "v1"
                });
            var apiDocumentationPath = Path.Combine(AppContext.BaseDirectory, "API.xml");
            config.IncludeXmlComments(apiDocumentationPath);
            var businesLayerDocumentationPath = Path.Combine(AppContext.BaseDirectory, "BusinessLayer.xml");
            config.IncludeXmlComments(businesLayerDocumentationPath);

            config.SchemaFilter<EnumSchemaFilter>();

            config.AddSecurityDefinition("access", new OpenApiSecurityScheme()
            {
                Description = "Access token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference = new OpenApiReference
                               {
                                   Type = ReferenceType.SecurityScheme,
                                   Id = "access"
                               }
                           },
                           new string[]{}
                       }
                   });


        });
        services.AddSwaggerExamplesFromAssemblies(typeof(UsersController).Assembly);

        return services;
    }

}