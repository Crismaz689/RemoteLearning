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
}
