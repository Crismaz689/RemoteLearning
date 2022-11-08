namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class CourseUserConfiguration : IEntityTypeConfiguration<CourseUser>
{
    public void Configure(EntityTypeBuilder<CourseUser> builder)
    {
        builder.ToTable("CourseUsers");

        builder.Property(p => p.CourseId)
            .IsRequired();

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.HasOne<Course>(cu => cu.Course)
            .WithMany(c => c.CourseUsers)
            .HasForeignKey(cu => cu.CourseId);

        builder.HasOne<User>(cu => cu.User)
            .WithMany(u => u.CourseUsers)
            .HasForeignKey(cu => cu.UserId);

        builder.HasIndex(c => new { c.CourseId, c.UserId })
            .IsUnique();
    }
}
