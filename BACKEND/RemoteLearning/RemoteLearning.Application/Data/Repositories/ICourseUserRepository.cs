namespace RemoteLearning.Application.Data.Repositories;

public interface ICourseUserRepository : IBaseRepository<CourseUser>
{
    Task<CourseUser> GetUserAssign(long userId, long courseId);

    Task<IEnumerable<CourseUser>> GetAssignments(long courseId);
}
