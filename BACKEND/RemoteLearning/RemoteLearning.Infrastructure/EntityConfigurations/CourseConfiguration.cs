namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();

        builder.Property(p => p.CreatorId)
            .IsRequired();

        builder.HasOne<User>(u => u.Creator)
            .WithMany(c => c.Courses)
            .HasForeignKey(u => u.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
