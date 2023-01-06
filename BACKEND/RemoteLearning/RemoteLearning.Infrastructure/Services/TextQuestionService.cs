using RemoteLearning.Application.DTOs.TextQuestion;

namespace RemoteLearning.Infrastructure.Services;

public class TextQuestionService : ITextQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TextQuestionService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<TextQuestionDto> CreateQuestion(CreateTextQuestionDto textQuestionDto, string userId)
    {
        var user = await _unitOfWork.Users.GetUserWithTests(Convert.ToInt64(userId));

        if ((textQuestionDto != null && user.Tests.FirstOrDefault(t => t.Id == textQuestionDto.TestId) != null) || (textQuestionDto != null && user.RoleId == 1))
        {
            var question = _mapper.Map<TextQuestion>(textQuestionDto);

            await _unitOfWork.TextQuestions.Create(question);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TextQuestionDto>(question);
            }
        }
        else
        {
            throw new TextQuestionNoPermissionException("You have no access to this operation.");
        }

        return null;
    }

    public async Task<bool> DeleteQuestion(long questionId, string userId)
    {
        var question = await _unitOfWork.TextQuestions.GetById(questionId);
        var user = await _unitOfWork.Users.GetUserWithTests(Convert.ToInt64(userId));

        if (user.Tests.FirstOrDefault(t => t.Id == question.TestId) != null || user.RoleId == 1)
        {
            await _unitOfWork.TextQuestions.Delete(questionId);

            return await _unitOfWork.SaveChangesAsync() != 0;
        }
        else
        {
            throw new TextQuestionNoPermissionException("You have no access to this operation.");
        }

        return false;
    }

    public async Task<TextQuestionDto> GetQuestionById(long questionId)
    {
        var question = await _unitOfWork.TextQuestions.GetById(questionId);

        return _mapper.Map<TextQuestionDto>(question);
    }

    public async Task<TextQuestionDto> UpdateQuestion(CreateTextQuestionDto textQuestionDto, long id, string userId)
    {
        var user = await _unitOfWork.Users.GetUserWithTests(Convert.ToInt64(userId));

        if ((textQuestionDto != null && user.Tests.FirstOrDefault(t => t.Id == textQuestionDto.TestId) != null) || (textQuestionDto != null && user.RoleId == 1))
        {
            var question = await _unitOfWork.TextQuestions.GetById(id);

            question.Title = textQuestionDto.Title;
            question.CorrectAnswer = textQuestionDto.CorrectAnswer;
            question.WrongAnswerA = textQuestionDto.WrongAnswerA;
            question.WrongAnswerB = textQuestionDto.WrongAnswerB;
            question.WrongAnswerC = textQuestionDto.WrongAnswerC;
            question.Points = textQuestionDto.Points;
            question.TimeMinutes = textQuestionDto.TimeMinutes;
            question.CreatorId = textQuestionDto.CreatorId;
            question.TestId = textQuestionDto.TestId;

            await _unitOfWork.TextQuestions.Update(question);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<TextQuestionDto>(question);
            }
        }
        else
        {
            throw new TextQuestionNoPermissionException("You have no access to this operation.");
        }

        return null;
    }
}
