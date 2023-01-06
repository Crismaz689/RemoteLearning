namespace RemoteLearning.Application.Services;

public interface ITextQuestionService
{
    Task<TextQuestionDto> GetQuestionById(long questionId);

    Task<bool> DeleteQuestion(long questionId, string userId);

    Task<TextQuestionDto> CreateQuestion(CreateTextQuestionDto textQuestionDto, string userId);

    Task<TextQuestionDto> UpdateQuestion(CreateTextQuestionDto textQuestionDto, long id, string userId);
}
