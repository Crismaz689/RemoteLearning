namespace RemoteLearning.Domain.Entities;

public class CourseUser : BaseEntity
{
    public virtual User User { get; set; }

    public long UserId { get; set; }

    public virtual Course Course { get; set; }

    public long CourseId { get; set; }
}