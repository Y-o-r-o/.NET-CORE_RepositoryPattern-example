using AzureFunctions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace AzureFunctions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var hostBuilder = new HostBuilder();
        hostBuilder
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("local.settings.json", optional: false, reloadOnChange: true)
                    .Build();

                services.ConfigureServices(config);
            });
        hostBuilder.Build().Run();
    }
}