namespace RemoteLearning.Infrastructure.DbContexts;

public class RemoteLearningDbContext : DbContext
{
    public RemoteLearningDbContext(DbContextOptions<RemoteLearningDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
