namespace RemoteLearning.Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<CourseDto> Create(CreateCourseDto courseDto, string userId)
    {
        if (courseDto != null && userId != null)
        {
            if (await DoesCourseAlreadyExist(courseDto.Name))
            {
                throw new CourseAlreadyExistsException("Course with given name already exists.");
            }

            var course = _mapper.Map<Course>(courseDto);
            course.CreatorId = Convert.ToInt64(userId);

            await _unitOfWork.Courses.Create(course);
            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                var fullCourse = await GetCourseById(course.Id);
                return _mapper.Map<CourseDto>(fullCourse);
            }
        }

        return null;
    }

    public async Task<IEnumerable<CourseDto>> GetMyCourses(string userId)
    {
        if (userId != null)
        {
            var courses = await _unitOfWork.Courses.GetMyCourses(Convert.ToInt64(userId));

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        return Enumerable.Empty<CourseDto>();
    }

    public async Task<IEnumerable<CourseDto>> GetAssignedCourses(string userId)
    {
        if (userId != null)
        {
            var courses = await _unitOfWork.Courses.GetAssignedCourses(Convert.ToInt64(userId));

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        return Enumerable.Empty<CourseDto>();
    }

    public async Task<bool> Delete(long courseId, string userId)
    {
        var course = await _unitOfWork.Courses.GetById(courseId);

        if (course == null)
        {
            throw new CourseDoesNotExists("Kurs o takim id nie istnieje!");
        }
        else if (string.IsNullOrEmpty(userId) || Convert.ToInt64(userId) != course.CreatorId)
        {
            throw new CourseMissingCreatorException("Nie mozesz wykonywać działań na kursie, który nie należy do Ciebie!");
        }

        await _unitOfWork.Courses.Delete(courseId);
        return await _unitOfWork.SaveChangesAsync() != 0;
    }

    public async Task<CourseDto> GetCourseById(long courseId)
    {
        var course = await _unitOfWork.Courses.GetWithCreator(courseId);

        return course != null ?
            _mapper.Map<CourseDto>(course) :
            null;
    }

    public async Task<CourseDto> Update(UpdateCourseDto courseDto, string userId)
    {
        var course = await _unitOfWork.Courses.GetById(courseDto.Id);

        if (course == null)
        {
            throw new CourseDoesNotExists("Course with given id does not exist.");
        }
        else if (Convert.ToInt64(userId) != course.CreatorId)
        {
            throw new CourseMissingCreatorException("You do not have permissions to perform update operation on this course.");
        }

        course.Name = courseDto.Name;
        course.Description = courseDto.Description;
        course.CreatorId = 2;
        course.ModificationDate = DateTime.Now;
        await _unitOfWork.Courses.Update(course);

        if (await _unitOfWork.SaveChangesAsync() != 0)
        {
            return _mapper.Map<CourseDto>(course);
        }

        return null;
    }

    private async Task<bool> DoesCourseAlreadyExist(string courseName) => await _unitOfWork.Courses.
        GetByName(courseName) != null;
}
