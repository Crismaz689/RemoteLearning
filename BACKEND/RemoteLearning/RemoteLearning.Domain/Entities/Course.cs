namespace RemoteLearning.Domain.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public User Creator { get; set; }

    public long CreatorId { get; set; }

    public ICollection<CourseSection> CourseSections { get; set; }

    public ICollection<CourseUser> CourseUsers { get; set; }
}