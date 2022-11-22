namespace RemoteLearning.Infrastructure.Data.Repositories;

public class SectionRepository : BaseRepository<Section>, ISectionRepository
{
    public SectionRepository(RemoteLearningDbContext context) : base(context) { }
}
