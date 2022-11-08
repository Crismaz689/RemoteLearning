namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(RemoteLearningDbContext context) : base(context) { }
}
