namespace RemoteLearning.Application.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses(string userId);

    Task<CourseAllDataDto> GetCourseById(long courseId, string userId);

    Task<IEnumerable<CourseDto>> GetMyCourses(string userId);

    Task<IEnumerable<CourseDto>> GetAllCoursesAdmin();

    Task<IEnumerable<CourseDto>> GetAssignedCourses(string userId);

    Task<bool> Delete(long courseId, string userId);

    Task<CourseDto> Create(CreateCourseDto courseDto, string userId);

    Task<CourseDto> Update(UpdateCourseDto courseDto, long id, string userId);
}
