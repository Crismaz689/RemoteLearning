namespace RemoteLearning.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateUser(string username, string password)
    {
        await _unitOfWork.Users.Create(new User()
        {
            Username = username,
            Password = password
        });
        await _unitOfWork.CompletedAsync();
    }
}
