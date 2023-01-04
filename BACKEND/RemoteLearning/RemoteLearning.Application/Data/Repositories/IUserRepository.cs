namespace RemoteLearning.Application.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByLogin(string username);

    Task<User> GetCreatedCourse(long courseId, long userId);

    Task<IEnumerable<User>> GetAllUsersWithDetails();
}
