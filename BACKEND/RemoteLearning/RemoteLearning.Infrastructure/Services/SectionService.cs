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
                throw new CreateSectionNoPermissionException("You do not have permission to create section in this course.");
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
        if (sectionId <= 0) 
        {
            return false;
        }

        var course = await _unitOfWork.Sections.GetById(sectionId);

        if (course != null)
        {
            if (await DoesUserHasPermission(course.Id, userId))
            {
                throw new CreateSectionNoPermissionException("You do not have permissions to delete the course.");
            }

            await _unitOfWork.Sections.Delete(sectionId);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<SectionDto> GetSectionById(long sectionId)
    {
        var section = await _unitOfWork.Sections.GetById(sectionId);

        return section != null ?
            _mapper.Map<SectionDto>(section) :
            null;
    }

    public async Task<SectionDto> UpdateSection(UpdateSectionDto sectionDto, string userId)
    {
        if (sectionDto.Id <= 0)
        {
            return null;
        }

        var course = await _unitOfWork.Sections.GetById(sectionDto.Id);

        if (course != null)
        {
            if (await DoesUserHasPermission(course.Id, userId))
            {
                throw new CreateSectionNoPermissionException("You do not have permissions to update the course.");
            }

            var section = await _unitOfWork.Sections.GetById(sectionDto.Id);
            section.Name = sectionDto.Name;
            section.Description = sectionDto.Description;
            section.ScheduleDate = sectionDto.ScheduleDate;
            section.ModificationDate = DateTime.Now;

            await _unitOfWork.Sections.Update(section);
            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<SectionDto>(section);
            }
        }

        return null;
    }

    private async Task<bool> DoesUserHasPermission(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;
}
