

using ServiceReference;

namespace ServiceClientLayer.ServiceClients.WCFTestService;

public class WCFTestService
{
    public async Task EchoAsync()
    {
        var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.BasicHttpBinding_IEchoService, "http://localhost:5000/EchoService/basichttp");

        var simpleResult = await client.EchoAsync("Hello");
        Console.WriteLine(simpleResult);

        var msg = new EchoMessage() { Text = "Hello2" };
        var msgResult = await client.ComplexEchoAsync(msg);
        Console.WriteLine(msgResult);
    }
}
