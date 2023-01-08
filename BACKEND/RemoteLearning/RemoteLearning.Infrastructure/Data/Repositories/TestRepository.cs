namespace RemoteLearning.Infrastructure.Data.Repositories;

public class TestRepository : BaseRepository<Test>, ITestRepository
{
    public TestRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<IEnumerable<Test>> GetAllTestsByAdmin() => await _context.Tests
        .Include(t => t.Course)
        .Include(t => t.Creator)
        .ToListAsync();

    public async Task<Test> GetWithQuestions(long id) => await _context.Tests
        .Include(t => t.TextQuestions)
        .Where(t => t.Id == id)
        .SingleOrDefaultAsync();
}
