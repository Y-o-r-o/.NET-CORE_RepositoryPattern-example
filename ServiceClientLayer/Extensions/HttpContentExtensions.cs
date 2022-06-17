using System.Text.Json;

namespace ServiceClientLayer.Extensions
{
    public static class HttpContentExtensions
    {
        public async static Task<T> Read<T>(this HttpContent content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var contentStream = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(contentStream, options);
        }
    }
}