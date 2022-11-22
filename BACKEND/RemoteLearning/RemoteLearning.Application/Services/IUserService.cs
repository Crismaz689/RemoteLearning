namespace RemoteLearning.Infrastructure.Services;

public interface IUserService
{
    Task<bool> CreateUsers(IEnumerable<CreateAccountDto> accountDtos);

    Task<string> Login(LoginDto loginDto);
}
