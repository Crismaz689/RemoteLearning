namespace RemoteLearning.Application.Data.Repositories;

public interface ITestRepository : IBaseRepository<Test>
{
    Task<Test> GetWithQuestions(long id);

    Task<IEnumerable<Test>> GetAllTestsByAdmin();
}
