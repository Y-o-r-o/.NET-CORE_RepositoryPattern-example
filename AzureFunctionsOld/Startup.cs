using AzureFunctions.Extensions;
using BusinessLayer.Enums;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

[assembly: FunctionsStartup(typeof(AzureFunctions.Startup))]

namespace AzureFunctions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var context = builder.GetContext();
        var config = context.Configuration;

        builder.Services.ConfigureServices(config);
    }

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        var context = builder.GetContext();

        builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false);
    }
}

internal class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
{
    public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;

    public override List<IDocumentFilter> DocumentFilters { get => base.DocumentFilters.Append(new EnumDocumentFilter()).ToList(); }
}

public class EnumDocumentFilter : IDocumentFilter
{
    public void Apply(IHttpRequestDataObject req, OpenApiDocument document)
    {
        foreach (var path in document.Paths)
            foreach (var operation in path.Value.Operations)
                foreach (var param in operation.Value.Parameters)
                    if (param.Schema.Enum.Any())
                    {
                        var schemaType = Assembly.GetAssembly(typeof(City)).GetTypes().Single(t => t.Name == MakePascalCase(param.Name));
                        param.Schema.Enum = Enum.GetNames(schemaType)
                            .Select(name => new OpenApiString(name))
                            .Cast<IOpenApiAny>()
                            .ToList();
                        param.Schema.Type = "string";
                        param.Schema.Default = param.Schema.Enum.First();
                        param.Schema.Format = null;
                    }
    }

    private static string MakePascalCase(string key)
        => $"{char.ToUpperInvariant(key[0])}{key[1..]}";
}