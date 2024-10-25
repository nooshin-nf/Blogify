namespace Blogify.Common;
public class ApiErrorModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }

    public ApiErrorModel(int statusCode, string? message, string? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}

