namespace RemoteLearning.Infrastructure.Data.Repositories;

public class GradeRepository : BaseRepository<Grade>, IGradeRepository
{
    public GradeRepository(RemoteLearningDbContext context) : base(context) { }
}
