namespace RemoteLearning.Application.Services;

public interface ICourseService
{
    Task<CourseDto> GetCourseById(long courseId);
}
