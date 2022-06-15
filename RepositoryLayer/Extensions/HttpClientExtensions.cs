using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RepositoryLayer.Extensions
{
    public static class HttpClientExtensions
    {

        public async static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string uri, IEnumerable<(string, string)> parameters)
        {
            var uriBuilder = new UriBuilder(httpClient.BaseAddress.AbsoluteUri + uri);
            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var parameter in parameters)
                paramValues.Add(parameter.Item1, parameter.Item2);
            uriBuilder.Query = paramValues.ToString();

            return await httpClient.GetAsync(uriBuilder.Uri);
        }
    }
}