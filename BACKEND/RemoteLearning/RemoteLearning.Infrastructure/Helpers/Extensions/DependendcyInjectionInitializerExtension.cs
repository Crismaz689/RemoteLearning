namespace RemoteLearning.Infrastructure.Helpers.Extensions;

public static class DependendcyInjectionInitializerExtension
{
    public static void CreateDependencyInjectionContainer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}
