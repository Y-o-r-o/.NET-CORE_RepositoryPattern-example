namespace Core;

public class AppException
{
    public AppException(int statusCode, string message, AdditionalInformation details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public AdditionalInformation Details { get; set; }

}

public class AdditionalInformation
{
    public string File { get; set; }
    public string MethodName { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }

}