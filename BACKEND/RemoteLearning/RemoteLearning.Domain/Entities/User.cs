namespace RemoteLearning.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public virtual UserDetails UserDetails { get; set; }

    public virtual Role Role { get; set; }

    public long RoleId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; }

    public virtual ICollection<Course> Courses { get; set; }

    public virtual ICollection<CourseUser> CourseUsers { get; set; }

    public virtual ICollection<Test> Tests { get; set; }

    public virtual ICollection<UserTestResult> UserTestResults { get; set; }
}
