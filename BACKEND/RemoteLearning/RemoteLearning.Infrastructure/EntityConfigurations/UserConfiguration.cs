namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasIndex(p => p.Username)
            .IsUnique();

        builder.HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder.HasMany<Course>(u => u.Courses)
            .WithOne(c => c.Creator)
            .HasForeignKey(c => c.CreatorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<UserTestResult>(u => u.UserTestResults)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
