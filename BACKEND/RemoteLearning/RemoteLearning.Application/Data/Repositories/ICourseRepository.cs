namespace RemoteLearning.Application.Data.Repositories;

public interface ICourseRepository : IBaseRepository<Course>
{
    Task<Course> GetCourseAllData(long courseId);

    Task<Course> GetWithCreator(long courseId);

    Task<IEnumerable<Course>> GetAllWithCreators(long userId);

    Task<IEnumerable<Course>> GetMyCourses(long userId);

    Task<IEnumerable<Course>> GetAssignedCourses(long userId);

    Task<Course> GetByName(string name);
}
