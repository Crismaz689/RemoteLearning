namespace RemoteLearning.Application.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses();

    Task<CourseAllDataDto> GetCourseById(long courseId, string userId);

    Task<IEnumerable<CourseDto>> GetMyCourses(string userId);

    Task<IEnumerable<CourseDto>> GetAssignedCourses(string userId);

    Task<bool> Delete(long courseId, string userId);

    Task<CourseDto> Create(CreateCourseDto courseDto, string userId);

    Task<CourseDto> Update(UpdateCourseDto courseDto, string userId);
}
