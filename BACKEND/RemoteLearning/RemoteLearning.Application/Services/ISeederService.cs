namespace RemoteLearning.Application.Services;

public interface ISeederService
{
    Task<bool> SeedRoles();
    Task<bool> SeedAccounts();
    Task<bool> SeedCategories();
    void CreateTriggers(IApplicationBuilder builder);
}
