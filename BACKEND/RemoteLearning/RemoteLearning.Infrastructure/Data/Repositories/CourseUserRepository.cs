namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CourseUserRepository : BaseRepository<CourseUser>, ICourseUserRepository
{
    public CourseUserRepository(RemoteLearningDbContext context) : base(context) { }
}
