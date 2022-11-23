namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CourseUserRepository : BaseRepository<CourseUser>, ICourseUserRepository
{
    public CourseUserRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<CourseUser> GetUserAssign(long userId, long courseId) => await _context.CourseUsers
        .SingleOrDefaultAsync(cu => cu.UserId == userId && cu.CourseId == courseId);
}
