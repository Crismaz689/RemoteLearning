namespace RemoteLearning.Infrastructure.Services;

public interface IUserService
{
    Task<User> CreateUser(CreateAccountDto accountDto);

    Task<User> Login(LoginDto loginDto);
}
