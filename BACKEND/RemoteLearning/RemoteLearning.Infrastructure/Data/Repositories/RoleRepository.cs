namespace RemoteLearning.Infrastructure.Data.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(RemoteLearningDbContext context) : base(context) { }
}
