namespace RemoteLearning.Domain.Entities;

public class Test : BaseEntity
{
    public string Name { get; set; }

    public decimal Points { get; set; }

    public int TimeMinutes { get; set; }

    public virtual Course Course { get; set; }

    public long CourseId { get; set; }

    public virtual User Creator { get; set; }

    public long CreatorId { get; set; }

    public virtual Grade? Grade { get; set; }

    public long? GradeId { get; set; }

    public virtual ICollection<TextQuestion> TextQuestions { get; set; }
}
