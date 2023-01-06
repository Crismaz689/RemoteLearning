using RemoteLearning.Infrastructure.Exceptions.Test;

namespace RemoteLearning.Infrastructure.Services;

public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<TestDto> CreateTest(CreateTestDto testDto, string userId)
    {
        var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));
        if (testDto != null && (await DoesUserHasPermission(testDto.CourseId, userId) || user.RoleId == 1))
        {
            var test = _mapper.Map<Test>(testDto);

            await _unitOfWork.Tests.Create(test);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TestDto>(test);
            }
        }
        else
        {
            throw new TestNoPermissionException("You have no access to this operation.");
        }

        return null;
    }

    public async Task<bool> DeleteTest(long testId, string userId)
    {
        var test = await _unitOfWork.Tests.GetById(testId);


        if (test == null)
        {
            return false;
        }
        else
        {
            var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));
            if (await DoesUserHasPermission(test.CourseId, userId) || user.RoleId == 1)
            {
                await _unitOfWork.Tests.Delete(testId);

                return await _unitOfWork.SaveChangesAsync() != 0;
            }
            else
            {
                throw new TestNoPermissionException("You have no access to this operation.");
            }
        }

        return false;
    }

    public async Task<TestDto> GetTestById(long testId, string userId)
    {
        var user = await _unitOfWork.Users.GetTestPermission(Convert.ToInt64(userId), testId);
        var test = await _unitOfWork.Tests.GetById(testId);

        if (test != null && user != null)
        {
            return _mapper.Map<TestDto>(test);
        }
        else
        {
            return null;
        }
    }

    public async Task<TestDto> UpdateTest(CreateTestDto testDto, long id, string userId)
    {
        var test = await _unitOfWork.Tests.GetById(id);
        var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));

        if (testDto != null && test != null && (await DoesUserHasPermission(testDto.CourseId, userId) || user.RoleId == 1))
        {
            test.Name = testDto.Name;

            await _unitOfWork.Tests.Update(test);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TestDto>(test);
            }
        }
        else
        {
            throw new TestNoPermissionException("You have no access to this operation.");
        }

        return null;
    }

    private async Task<bool> DoesUserHasPermission(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;
}
