using System.Net;
using System.Web.Http;

namespace Core;

public class HttpResponseException : System.Web.Http.HttpResponseException
{
    public HttpResponseException(HttpStatusCode statusCode) : base(statusCode)
    {
    }

    public override string Message => Response.ReasonPhrase;
}
