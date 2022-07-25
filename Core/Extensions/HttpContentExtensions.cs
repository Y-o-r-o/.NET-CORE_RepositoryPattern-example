namespace Core.Extensions;

public static class HttpContentExtensions
{
    public static async Task<T?> Read<T>(this HttpContent content)
    {
        var contentStream = await content.ReadAsStreamAsync();
        return await contentStream.DeserializeAsync<T>();
    }
}