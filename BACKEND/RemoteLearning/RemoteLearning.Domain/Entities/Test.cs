namespace RemoteLearning.Domain.Entities;

public class Test : BaseEntity
{
    public string Name { get; set; }

    public decimal Points { get; set; }

    public int Time { get; set; }

    public ICollection<TestTextQuestion> TestTextQuestions { get; set; }
}
