namespace RemoteLearning.Infrastructure.Services;

public interface IUserService
{
    Task<bool> CreateUsers(IEnumerable<CreateAccountDto> accountDtos);

    Task<IEnumerable<UserDetailedDto>> GetAllUsers();

    Task<UserDto> Login(LoginDto loginDto);

    Task<bool> DeleteUser(long userId);
}
