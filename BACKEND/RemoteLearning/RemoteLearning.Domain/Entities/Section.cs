namespace RemoteLearning.Domain.Entities;

public class Section : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime ScheduleDate { get; set; }

    public virtual Course Course { get; set; }

    public long CourseId { get; set; }

    public virtual ICollection<File> Files { get; set; }
}
