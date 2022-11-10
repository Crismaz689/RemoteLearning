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
            PasswordHash = new byte[1],
            PasswordSalt = new byte[1],
            RoleId = 1
        });;

        if (await _unitOfWork.SaveChangesAsync() == 0)
        {
            throw new DbUpdateException();
        }
    }
}
