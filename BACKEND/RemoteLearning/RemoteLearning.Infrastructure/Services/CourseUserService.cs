namespace RemoteLearning.Infrastructure.Services;

public class CourseUserService : ICourseUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseUserService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<long> CreateAssignment(long courseId, string userId)
    {
        if (await IsUserAlreadyAssigned(courseId, userId) || await IsUserCourseOwner(courseId, userId))
        {
            throw new UserAlreadyAssigned("You are already assigned to this course or you are its owner.");
        }

        var courseUser = new CourseUser()
        {
            CourseId = courseId,
            UserId = Convert.ToInt64(userId)
        };

        await _unitOfWork.CourseUsers.Create(courseUser);

        if (await _unitOfWork.SaveChangesAsync() != 0)
        {
            return courseUser.Id;
        }

        return -1;
    }

    public async Task<bool> DeleteAssignment(long courseId, string userId)
    {
        var assignment = await _unitOfWork.CourseUsers.GetUserAssign(Convert.ToInt64(userId), courseId);

        if (assignment != null)
        {
            await _unitOfWork.CourseUsers.Delete(assignment.Id);

            return await _unitOfWork.SaveChangesAsync() != 0;
        }

        return false;
    }

    private async Task<bool> IsUserAlreadyAssigned(long courseId, string userId) => await _unitOfWork.CourseUsers.GetUserAssign(Convert.ToInt64(userId), courseId) != null;

    private async Task<bool> IsUserCourseOwner(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;
}
