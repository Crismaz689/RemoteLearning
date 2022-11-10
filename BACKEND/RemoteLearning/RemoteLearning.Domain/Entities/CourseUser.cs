namespace RemoteLearning.Domain.Entities;

public class CourseUser : BaseEntity
{
    public User User { get; set; }

    public long UserId { get; set; }

    public Course Course { get; set; }

    public long CourseId { get; set; }
}