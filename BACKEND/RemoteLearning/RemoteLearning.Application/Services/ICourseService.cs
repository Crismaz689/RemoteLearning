namespace RemoteLearning.Application.Services;

public interface ICourseService
{
    Task<CourseDto> GetCourseById(long courseId);

    Task<bool> Delete(long courseId, string userId);

    Task<CourseDto> Create(CreateCourseDto courseDto);

    Task<CourseDto> Update(UpdateCourseDto courseDto, string userId);
}
