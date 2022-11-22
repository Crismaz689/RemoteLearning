namespace RemoteLearning.Application.Services;

public interface ISeederService
{
    Task<bool> SeedRoles();
    Task<bool> SeedAccounts();
}
