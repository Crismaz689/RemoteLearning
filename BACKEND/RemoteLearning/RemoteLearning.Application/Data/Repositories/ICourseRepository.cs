namespace RemoteLearning.Application.Data.Repositories;

public interface ICourseRepository : IBaseRepository<Course>
{
    Task<Course> GetWithCreator(long courseId);
}
