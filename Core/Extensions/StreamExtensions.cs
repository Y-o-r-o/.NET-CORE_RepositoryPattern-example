using System.Text.Json;

namespace Core.Extensions;

public static class StreamExtensions
{
    public static async Task<T?> DeserializeAsync<T>(this Stream stream)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
        };
        return await JsonSerializer.DeserializeAsync<T>(stream, options);
    }
}