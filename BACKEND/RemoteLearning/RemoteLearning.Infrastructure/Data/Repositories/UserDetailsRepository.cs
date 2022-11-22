namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserDetailsRepository : BaseRepository<UserDetails>, IUserDetailsRepository
{
    public UserDetailsRepository(RemoteLearningDbContext context) : base(context) { }
    public async Task<UserDetails> GetUserByEmail(string email) => await _context.UsersDetails.
        SingleOrDefaultAsync(e => e.Email == email);

    public async Task<UserDetails> GetUserByPesel(string pesel) => await _context.UsersDetails.
        SingleOrDefaultAsync(e => e.Pesel == pesel);
}
