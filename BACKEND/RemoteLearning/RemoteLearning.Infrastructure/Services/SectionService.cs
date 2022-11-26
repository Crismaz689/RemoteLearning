namespace RemoteLearning.Infrastructure.Services;

public class SectionService : ISectionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SectionService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<SectionDto> CreateSection(CreateSectionDto sectionDto, string userId)
    {
        if (sectionDto != null)
        {
            if (string.IsNullOrEmpty(userId) || !await DoesUserHasPermission(sectionDto.CourseId, userId))
            {
                throw new CreateSectionNoPermissionException("Nie masz uprawnień do stworzenia sekcji w tym kursie!");
            }

            var section = _mapper.Map<Section>(sectionDto);

            await _unitOfWork.Sections.Create(section);
            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<SectionDto>(section);
            }
        }

        return null;
    }

    public async Task<bool> DeleteSection(long sectionId, string userId)
    {
        /*if (await DoesUserHasPermission(courseId, userId))
        {
            throw new CreateSectionNoPermissionException("Nie masz uprawnień do stworzenia sekcji w tym kursie!");
        }*/

        return false;
    }

    public async Task<SectionDto> GetSectionById(long sectionId)
    {
        throw new NotImplementedException();
    }

    public async Task<SectionDto> UpdateSection(UpdateSectionDto sectionDto, string userId)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> DoesUserHasPermission(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;
}
