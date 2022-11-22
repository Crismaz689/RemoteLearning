namespace RemoteLearning.Infrastructure.DbContexts;

public class RemoteLearningDbContext : DbContext
{
    public RemoteLearningDbContext(DbContextOptions<RemoteLearningDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseUser> CourseUsers { get; set; }
    public DbSet<Domain.Entities.File> Files { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserDetails> UsersDetails { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<TextQuestion> TextQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
