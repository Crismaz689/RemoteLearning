namespace RemoteLearning.Domain.Entities;

public class Grade : BaseEntity
{
    public decimal Value { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public virtual User User { get; set; }

    public long UserId { get; set; }

    public virtual Category Category { get; set; }

    public long CourseId { get; set; }

    public virtual Course Course { get; set; }

    public long CategoryId { get; set; }
}
