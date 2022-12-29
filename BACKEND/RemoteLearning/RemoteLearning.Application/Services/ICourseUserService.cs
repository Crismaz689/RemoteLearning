namespace RemoteLearning.Application.Services;

public interface ICourseUserService
{
    Task<long> CreateAssignment(long courseId, string userId);

    Task<bool> DeleteAssignment(long courseId, string userId);
}
