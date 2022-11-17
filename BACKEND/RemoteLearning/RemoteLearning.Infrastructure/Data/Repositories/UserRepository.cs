namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<User> GetUserByLogin(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username.Equals(username));
    }
}
