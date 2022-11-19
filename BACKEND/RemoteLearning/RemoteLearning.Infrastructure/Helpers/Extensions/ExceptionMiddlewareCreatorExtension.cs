namespace RemoteLearning.Infrastructure.Helpers.Extensions;

public static class ExceptionMiddlewareCreatorExtension
{
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionMiddleware>();
    }
}
