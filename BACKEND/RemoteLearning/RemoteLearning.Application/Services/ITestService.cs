namespace RemoteLearning.Application.Services;

public interface ITestService
{
    Task<TestDto> GetTestById(long testId);

    Task<bool> DeleteTest(long testId);

    Task<TestDto> CreateTest(CreateTestDto testDto);

    Task<TestDto> UpdateTest(CreateTestDto testDto);
}
