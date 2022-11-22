namespace RemoteLearning.Infrastructure.Data.Repositories;

public class FileRepository : BaseRepository<Domain.Entities.File>, IFileRepository
{
    public FileRepository(RemoteLearningDbContext context) : base(context) { }
}
