using Microsoft.Extensions.Hosting;

namespace RemoteLearning.Infrastructure.Exceptions.Middleware;

public class ExceptionMiddleware
{
    private readonly ILogger _logger;
    private readonly IHostEnvironment _environment;

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        => (_next, _logger, _environment) = (next, logger, environment);

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError($"{ex.Message}");
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
        _ => _environment.IsDevelopment() ?
        new ExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message) :
        new ExceptionResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString())
    };
}
