namespace RemoteLearning.Application.Services;

public interface ISectionService
{
    Task<SectionDto> GetSectionById(long sectionId);

    Task<bool> DeleteSection(long sectionId, string userId);

    Task<SectionDto> CreateSection(CreateSectionDto sectionDto);

    Task<SectionDto> UpdateSection(UpdateSectionDto sectionDto, string userId);
}
