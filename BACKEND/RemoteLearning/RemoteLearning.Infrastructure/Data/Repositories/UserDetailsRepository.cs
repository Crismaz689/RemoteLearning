namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserDetailsRepository : BaseRepository<UserDetails>, IUserDetailsRepository
{
    public UserDetailsRepository(RemoteLearningDbContext context) : base(context) { }
    public async Task<UserDetails> GetUserByEmail(string email)
    {
        return await _context.UsersDetails.SingleOrDefaultAsync(e => e.Email == email);
    }
}
