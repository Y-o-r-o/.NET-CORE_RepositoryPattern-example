using System.Collections.Specialized;
using System.Web;
using Microsoft.Azure.Functions.Worker.Http;

namespace Core.Extensions;
public static class HttpRequestDataExtensions
{
    public static NameValueCollection QueryDictionary(this HttpRequestData req)
    {
        return HttpUtility.ParseQueryString(req.Url.Query);
    }
}