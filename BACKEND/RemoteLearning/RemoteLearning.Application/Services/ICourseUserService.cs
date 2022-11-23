namespace RemoteLearning.Application.Services;

public interface ICourseUserService
{
    Task<long> Create(CreateCourseUserDto courseUserDto);
}
