namespace RemoteLearning.Application.Data.Repositories;

public interface ISectionRepository : IBaseRepository<Section>
{
    Task<Section> GetSectionWithFiles(long sectionId);
}
