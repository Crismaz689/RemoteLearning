namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<IEnumerable<User>> GetAllUsersWithDetails() => await _context.Users
        .Include(u => u.UserDetails)
        .ToListAsync();

    public async Task<User> GetCreatedCourse(long courseId, long userId) => await _context.Users
        .Include(u => u.Courses)
        .Where(u => u.Id == userId && u.Courses.Any(c => c.Id == courseId))
        .SingleOrDefaultAsync();

    public async Task<User> GetUserByLogin(string username) => await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Username.Equals(username));

    public async Task<User> GetTestPermission(long userId, long testId) => await _context.Users
        .Include(u => u.Tests)
        .Include(u => u.CourseUsers)
        .Where(u => u.CourseUsers.Any(cu => cu.UserId == userId && u.Tests.SingleOrDefault(t => t.Id == testId).CourseId == cu.CourseId))
        .SingleOrDefaultAsync();

    public async Task<User> GetUserWithTests(long id) => await _context.Users
        .Include(u => u.Tests)
        .SingleOrDefaultAsync(u => u.Id == id);
}
