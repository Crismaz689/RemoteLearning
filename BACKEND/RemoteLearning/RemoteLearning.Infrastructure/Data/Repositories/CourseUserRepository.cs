namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CourseUserRepository : BaseRepository<CourseUser>, ICourseUserRepository
{
    public CourseUserRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<IEnumerable<CourseUser>> GetAssignments(long courseId) => await _context.CourseUsers
        .Include(cu => cu.User)
        .ThenInclude(user => user.UserDetails)
        .Where(cu => cu.CourseId == courseId)
        .ToListAsync();

    public async Task<CourseUser> GetUserAssign(long userId, long courseId) => await _context.CourseUsers
        .SingleOrDefaultAsync(cu => cu.UserId == userId && cu.CourseId == courseId);
}
