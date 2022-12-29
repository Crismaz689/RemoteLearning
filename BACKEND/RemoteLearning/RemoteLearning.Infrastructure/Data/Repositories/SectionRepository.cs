namespace RemoteLearning.Infrastructure.Data.Repositories;

public class SectionRepository : BaseRepository<Section>, ISectionRepository
{
    public SectionRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<Section> GetSectionWithFiles(long sectionId) => await _context.Sections
        .Where(section => section.Id == sectionId)
        .Include(section => section.Files)
        .SingleOrDefaultAsync();
}
