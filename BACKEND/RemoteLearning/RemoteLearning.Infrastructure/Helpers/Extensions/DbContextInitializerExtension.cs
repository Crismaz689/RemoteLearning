namespace RemoteLearning.Infrastructure.Extensions;

public static class DbContextInitializerExtension
{
    public static void InitializeDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RemoteLearningDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
    }
}
