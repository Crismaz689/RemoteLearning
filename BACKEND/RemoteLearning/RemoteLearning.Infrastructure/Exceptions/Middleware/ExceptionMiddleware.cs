namespace RemoteLearning.Infrastructure.Exceptions.Middleware;

public class ExceptionMiddleware
{
    //private readonly ILogger _logger;

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        //_logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            //_logger.LogError($"test");
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        ExceptionResponse response = CreateResponse(ex);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private ExceptionResponse CreateResponse(Exception ex) => ex switch
    {
        BaseException baseException => new ExceptionResponse(baseException.StatusCode, baseException.Message),
        _ => new ExceptionResponse(500, "Wewnętrzny błąd serwera!")
    };
}
