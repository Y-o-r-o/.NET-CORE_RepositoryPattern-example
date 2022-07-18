using System.Net;

namespace Core;

public class HttpResponseException : System.Web.Http.HttpResponseException
{
    private string? _message = null;

    private string _statusCodeMessage;

    public HttpResponseException(HttpStatusCode statusCode, string? message = null) : base(statusCode)
    {
        StatusCode = statusCode;
        _statusCodeMessage = statusCode.ToString();
        _message = message;
    }

    public HttpStatusCode StatusCode { get; }

    public override string Message => _message is null ? _statusCodeMessage : _message;
}