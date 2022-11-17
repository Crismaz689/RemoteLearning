namespace RemoteLearning.Application.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByLogin(string username);
}
