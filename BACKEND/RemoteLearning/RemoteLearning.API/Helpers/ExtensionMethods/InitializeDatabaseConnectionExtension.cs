using System;

namespace RemoteLearning.API.Helpers.ExtensionMethods;

public static class InitializeDatabaseConnectionExtension
{
    public static void InitializeDatabaseConnection(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<RemoteLearningDbContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("Default"));
        });
    }
}
