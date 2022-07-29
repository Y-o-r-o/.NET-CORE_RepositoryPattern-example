using AzureFunctions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace AzureFunctions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var hostBuilder = new HostBuilder();
        hostBuilder.ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                string jsonString = "{\"IsEncrypted\": false,\"Values\": {\"AzureWebJobsStorage\": \"UseDevelopmentStorage=true\",\"FUNCTIONS_WORKER_RUNTIME\": \"dotnet-isolated\"},\"OpenWeatherMapSettings\": {\"ApiKey\": \"23c3b2473a324e52b6c12751a5a5b424\"},\"GoogleMapsSettings\": {\"ApiKey\": \"AIzaSyCURMqvErzLSfyY3qFoMeZncH6qnkY0vXc\",\"OutputFormat\": \"json\"}}";
                var config = new ConfigurationBuilder()
                    .AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(jsonString)))
                    .Build();

                services.ConfigureServices(config);
            });
        hostBuilder.Build().Run();
    }
}