namespace RemoteLearning.Infrastructure.Services;

public class SectionService : ISectionService
{
    public async Task<SectionDto> CreateSection(CreateSectionDto sectionDto)
    {
        /*if (sectionDto != null && await DoesUserHasPermission(sectionDto))
        {

        }*/
        return null;
    }

    public async Task<bool> DeleteSection(long sectionId, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<SectionDto> GetSectionById(long sectionId)
    {
        throw new NotImplementedException();
    }

    public async Task<SectionDto> UpdateSection(UpdateSectionDto sectionDto, string userId)
    {
        throw new NotImplementedException();
    }

    /*private async DoesUserHasPermission(T dto)
    {

    }
    */
}
