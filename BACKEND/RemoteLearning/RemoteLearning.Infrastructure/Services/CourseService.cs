namespace RemoteLearning.Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CourseDto> Create(CreateCourseDto courseDto)
    {
        if (courseDto != null)
        {
            if (await DoesCourseAlreadyExist(courseDto.Name))
            {
                throw new CourseAlreadyExistsException("Kurs o takiej nazwie już istnieje!");
            }

            var course = _mapper.Map<Course>(courseDto);

            await _unitOfWork.Courses.Create(course);
            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                var fullCourse = await GetCourseById(course.Id);
                return _mapper.Map<CourseDto>(fullCourse);
            }
        }

        return null;
    }

    public async Task<bool> Delete(long courseId, string userId)
    {
        var course = await _unitOfWork.Courses.GetById(courseId);

        if (course == null)
        {
            throw new CourseDoesNotExists("Kurs o takim id nie istnieje!");
        }
        else if (Convert.ToInt64(userId) == course.CreatorId)
        {
            throw new CourseMissingCreatorException("Nie mozesz wykonywać działań na kursie, który nie należy do Ciebie!");
        }

        await _unitOfWork.Courses.Delete(courseId);
        return await _unitOfWork.SaveChangesAsync() != 0;
    }

    public async Task<CourseDto> GetCourseById(long courseId)
    {
        var course = await _unitOfWork.Courses.GetWithCreator(courseId);

        if (course != null)
        {
            return _mapper.Map<CourseDto>(course);
        }
        else
        {
            return null;
        }
    }

    public async Task<CourseDto> Update(UpdateCourseDto courseDto, string userId)
    {
        var course = await _unitOfWork.Courses.GetById(courseDto.Id);

        if (course == null)
        {
            throw new CourseDoesNotExists("Kurs o takim id nie istnieje!");
        }
        else if (Convert.ToInt64(userId) == course.CreatorId)
        {
            throw new CourseMissingCreatorException("Nie mozesz wykonywać działań na kursie, który nie należy do Ciebie!");
        }

        var updatingCourse = _mapper.Map<Course>(courseDto);
        _unitOfWork.Courses.Update(updatingCourse);

        if (await _unitOfWork.SaveChangesAsync() != 0)
        {
            return _mapper.Map<CourseDto>(updatingCourse);
        }

        return null;
    }

    private async Task<bool> DoesCourseAlreadyExist(string courseName) => await _unitOfWork.Courses.
        GetByName(courseName) != null;
}
