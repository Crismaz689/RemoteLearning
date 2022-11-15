namespace RemoteLearning.Domain.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public virtual User Creator { get; set; }

    public long CreatorId { get; set; }

    public virtual ICollection<Section> Sections { get; set; }

    public virtual ICollection<CourseUser> CourseUsers { get; set; }
}