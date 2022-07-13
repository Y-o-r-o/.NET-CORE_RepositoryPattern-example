namespace API;

public class AppException
{
    public AppException(int statusCode, string message, AdditionalInformation? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    /// <summary>
    /// Http status code
    /// </summary>
    /// <example>500</example>
    public int StatusCode { get; set; }

    /// <summary>
    /// Http error message
    /// </summary>
    /// <example>Internal server error.</example>
    public string Message { get; set; }

    /// <summary>
    /// Http error details (dev only)
    /// </summary>
    public AdditionalInformation? Details { get; set; }
}

public class AdditionalInformation
{
    /// <summary>
    /// File in witch exception was triggered.
    /// </summary>
    /// <example>C:\\Project\\API\\Controllers\\SomeController.cs</example>
    public string? File { get; set; }

    /// <summary>
    /// Http status code
    /// </summary>
    /// <example>API.Controllers.SomeController GetSomething d__2</example>
    public string? MethodName { get; set; }

    /// <summary>
    /// Line in witch exception was triggered.
    /// </summary>
    /// <example>26</example>
    public int Line { get; set; }

    /// <summary>
    /// Column in witch exception was triggered.
    /// </summary>
    /// <example>9</example>
    public int Column { get; set; }
}