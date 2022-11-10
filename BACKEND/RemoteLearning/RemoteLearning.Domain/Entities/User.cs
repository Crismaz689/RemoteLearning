namespace RemoteLearning.Domain.Entities;

public class User : BaseEntity
{
    public string? Username { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public UserDetails UserDetails { get; set; }

    public Role Role { get; set; }

    public long RoleId { get; set; }

    public ICollection<Grade> Grades { get; set; }

    public ICollection<Course> Courses { get; set; }

    public ICollection<CourseUser> CourseUsers { get; set; }
}
