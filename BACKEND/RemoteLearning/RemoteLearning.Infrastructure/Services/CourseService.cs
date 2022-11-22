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
}
