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

    public async Task<User> GetTestPermission(long userId, long testId)
    {
        var user = await _context.Users
            .Include(u => u.CourseUsers)
            .Include(u => u.Tests)
            .ThenInclude(t => t.TextQuestions)
            .SingleOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            var test = await _context.Tests.SingleOrDefaultAsync(t => t.Id == testId);
            var check = user.CourseUsers.SingleOrDefault(cu => cu.UserId == userId && test.CourseId == cu.CourseId);

            return check != null ?
                user :
                null;
        }

        return null;
    }

    public async Task<User> GetUserWithTests(long id) => await _context.Users
        .Include(u => u.Tests)
        .SingleOrDefaultAsync(u => u.Id == id);

    public async Task<User> GetUserWithCourses(long id) => await _context.Users
        .Include(u => u.Courses)
        .SingleOrDefaultAsync(u => u.Id == id);
}
