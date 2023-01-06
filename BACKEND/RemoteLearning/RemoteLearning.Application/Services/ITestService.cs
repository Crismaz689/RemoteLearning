namespace RemoteLearning.Application.Services;

public interface ITestService
{
    Task<TestDto> GetTestById(long testId, string userId);

    Task<bool> DeleteTest(long testId, string userId);

    Task<TestDto> CreateTest(CreateTestDto testDto, string userId);

    Task<TestDto> UpdateTest(CreateTestDto testDto, long id, string userId);
}
