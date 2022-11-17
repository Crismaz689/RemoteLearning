namespace RemoteLearning.Infrastructure.Extensions;

public static class DatabaseInitializerExtension
{
    public static void InitializeDatabase(this IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<RemoteLearningDbContext>();

            if (context is null)
            {
                return;
            }

            context.Database.EnsureCreated();
        }
    }
}
