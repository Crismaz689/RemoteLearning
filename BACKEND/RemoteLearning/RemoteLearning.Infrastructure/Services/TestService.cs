namespace RemoteLearning.Infrastructure.Services;

public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<TestDto> CreateTest(CreateTestDto testDto)
    {
        if (testDto != null)
        {
            var test = _mapper.Map<Test>(testDto);

            await _unitOfWork.Tests.Create(test);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TestDto>(test);
            }
        }

        return null;
    }

    public async Task<bool> DeleteTest(long testId)
    {
        var test = await _unitOfWork.Tests.GetById(testId);

        if (test == null)
        {
            return false;
        }

        await _unitOfWork.Tests.Delete(testId);

        return await _unitOfWork.SaveChangesAsync() != 0;
    }

    public async Task<TestDto> GetTestById(long testId)
    {
        var test = await _unitOfWork.Tests.GetById(testId);

        if (test != null)
        {
            return _mapper.Map<TestDto>(test);
        }
        else
        {
            return null;
        }
    }

    public Task<TestDto> UpdateTest(CreateTestDto testDto)
    {
        throw new NotImplementedException();
    }
}
