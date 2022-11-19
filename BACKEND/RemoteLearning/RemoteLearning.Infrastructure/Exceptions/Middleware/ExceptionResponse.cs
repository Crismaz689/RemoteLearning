namespace RemoteLearning.Infrastructure.Exceptions.Middleware;

public class ExceptionResponse
{
    public int StatusCode { get; set; } = 500;
    public string Message { get; set; } = string.Empty;

    public ExceptionResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
