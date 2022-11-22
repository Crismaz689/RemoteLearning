using Serilog;

namespace RemoteLearning.Infrastructure.Helpers.Extensions;

public static class SerilogInitializerExtension
{
    public static void InitializeSerilog(this ILoggingBuilder builder, IConfiguration config)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/logs-info.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day)
            .WriteTo.File("logs/logs-errors.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.ClearProviders();
        builder.AddSerilog(logger);
    }
}