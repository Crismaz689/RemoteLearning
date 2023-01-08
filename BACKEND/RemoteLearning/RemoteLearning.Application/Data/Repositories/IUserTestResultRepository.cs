namespace RemoteLearning.Application.Data.Repositories;

public interface IUserTestResultRepository : IBaseRepository<UserTestResult>
{
    Task<UserTestResult> GetResults(long testId, long userId);
}
