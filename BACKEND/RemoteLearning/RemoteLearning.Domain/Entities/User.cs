namespace RemoteLearning.Domain.Entities;

public class User : BaseEntity
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public ICollection<Grade> Grades { get; set; }

    public ICollection<Course> Courses { get; set; }

    public ICollection<CourseUser> CourseUsers { get; set; }
}
