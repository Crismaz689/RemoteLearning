namespace RemoteLearning.Infrastructure.Services;

public interface IUserService
{
    Task CreateUser(string username, string password);
}
