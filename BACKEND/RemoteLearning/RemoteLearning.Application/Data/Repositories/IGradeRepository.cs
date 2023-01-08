namespace RemoteLearning.Application.Data.Repositories;

public interface IGradeRepository : IBaseRepository<Grade>
{
    Task<IEnumerable<Grade>> GetUserGrades(long userId);
    Task<IEnumerable<Grade>> GetAllUsersGrades();
}
