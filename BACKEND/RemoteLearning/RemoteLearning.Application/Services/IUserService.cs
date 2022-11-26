namespace RemoteLearning.Infrastructure.Services;

public interface IUserService
{
    Task<bool> CreateUsers(IEnumerable<CreateAccountDto> accountDtos);

    Task<UserDto> Login(LoginDto loginDto);
}
