namespace RemoteLearning.Domain.Entities;

public class TestTextQuestion : BaseEntity
{
    public string Title { get; set; }

    public string CorrectAnswer { get; set; }

    public string WrongAnswerA { get; set; }

    public string WrongAnswerB { get; set; }

    public string WrongAnswerC { get; set; }

    public decimal Points { get; set; }

    public int Time { get; set; }

}