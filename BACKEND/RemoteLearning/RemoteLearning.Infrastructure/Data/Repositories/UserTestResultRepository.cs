namespace RemoteLearning.Infrastructure.Data.Repositories;

public class UserTestResultRepository : BaseRepository<UserTestResult>, IUserTestResultRepository
{
    public UserTestResultRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<UserTestResult> GetResults(long testId, long userId) => await _context.UsersTestsResults
        .SingleOrDefaultAsync(utr => utr.UserId == userId && utr.TestId == testId);
}
