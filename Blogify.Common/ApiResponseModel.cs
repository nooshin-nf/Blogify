namespace Blogify.Common;
public class ApiResponseModel<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public ApiResponseModel()
    {
        Success = true;
    }

    public ApiResponseModel(T data)
    {
        Success = true;
        Data = data;
        Message = "The operation has completed successfully.";
    }

    public ApiResponseModel(string message)
    {
        Success = true;
        Message = message;
    }

    public ApiResponseModel(string message, T data)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public ApiResponseModel(string message, bool success)
    {
        Success = success;
        Message = message;
    }
}