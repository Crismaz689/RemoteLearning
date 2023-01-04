namespace RemoteLearning.Domain.Entities;

public class TextQuestion : BaseEntity
{
    public string Title { get; set; }

    public string CorrectAnswer { get; set; }

    public string WrongAnswerA { get; set; }

    public string WrongAnswerB { get; set; }

    public string WrongAnswerC { get; set; }

    public decimal Points { get; set; }

    public int TimeMinutes { get; set; }

    public virtual User Creator { get; set; }

    public long CreatorId { get; set; }

    public virtual Test Test { get; set; }

    public long TestId { get; set; }
}
