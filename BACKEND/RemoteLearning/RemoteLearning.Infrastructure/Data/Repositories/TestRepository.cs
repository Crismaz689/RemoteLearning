namespace RemoteLearning.Infrastructure.Data.Repositories;

public class TestRepository : BaseRepository<Test>, ITestRepository
{
    public TestRepository(RemoteLearningDbContext context) : base(context) { }
}
