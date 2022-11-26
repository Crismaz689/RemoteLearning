namespace RemoteLearning.Application.Services;

public interface ITextQuestionService
{
    Task<TextQuestionDto> GetQuestionById(long questionId);

    Task<bool> DeleteQuestion(long questionId);

    Task<TextQuestionDto> CreateQuestion(CreateTextQuestionDto textQuestionDto);

    Task<TextQuestionDto> UpdateQuestion(CreateTextQuestionDto textQuestionDto);
}
