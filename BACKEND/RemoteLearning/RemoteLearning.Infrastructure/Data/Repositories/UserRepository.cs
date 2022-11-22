namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<User> GetUserByLogin(string username) => await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Username.Equals(username));
}
