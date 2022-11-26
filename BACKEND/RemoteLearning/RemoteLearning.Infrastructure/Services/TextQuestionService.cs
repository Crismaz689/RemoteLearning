namespace RemoteLearning.Infrastructure.Services;

public class TextQuestionService : ITextQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TextQuestionService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<TextQuestionDto> CreateQuestion(CreateTextQuestionDto textQuestionDto)
    {
        if (textQuestionDto != null)
        {
            var question = _mapper.Map<TextQuestion>(textQuestionDto);

            await _unitOfWork.TextQuestions.Create(question);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TextQuestionDto>(question);
            }
        }

        return null;
    }

    public Task<bool> DeleteQuestion(long questionId)
    {
        throw new NotImplementedException();
    }

    public Task<TextQuestionDto> GetQuestionById(long questionId)
    {
        throw new NotImplementedException();
    }

    public Task<TextQuestionDto> UpdateQuestion(CreateTextQuestionDto textQuestionDto)
    {
        throw new NotImplementedException();
    }
}
