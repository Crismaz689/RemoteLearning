namespace RemoteLearning.Domain.Entities;

public class Test : BaseEntity
{
    public string Name { get; set; }

    public decimal Points { get; set; }

    public int TimeMinutes { get; set; }

    public virtual Grade? Grade { get; set; }

    public long? GradeId { get; set; }

    public virtual ICollection<TextQuestion> TextQuestions { get; set; }
}
