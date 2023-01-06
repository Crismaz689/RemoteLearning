namespace RemoteLearning.Application.DTOs.TextQuestion;

public class TextQuestionDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string CorrectAnswer { get; set; }

    public string WrongAnswerA { get; set; }

    public string WrongAnswerB { get; set; }

    public string WrongAnswerC { get; set; }

    public decimal Points { get; set; }

    public int TimeMinutes { get; set; }

    public long TestId { get; set; }

    public long CreatorId { get; set; }
}
