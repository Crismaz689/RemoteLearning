namespace RemoteLearning.Application.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByLogin(string username);

    Task<User> GetUserWithTests(long id);

    Task<User> GetCreatedCourse(long courseId, long userId);

    Task<User> GetTestPermission(long userId, long testId);

    Task<IEnumerable<User>> GetAllUsersWithDetails();
}
