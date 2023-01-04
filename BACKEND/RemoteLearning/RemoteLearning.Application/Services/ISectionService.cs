namespace RemoteLearning.Application.Services;

public interface ISectionService
{
    Task<SectionDto> GetSectionById(long sectionId);

    Task<bool> DeleteSection(long sectionId, string userId);

    Task<SectionDto> CreateSection(CreateSectionDto sectionDto, string userId);

    Task<SectionDto> UpdateSection(UpdateSectionDto sectionDto, long sectionId, string userId);
}
