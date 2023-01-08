namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.ToTable("Tests");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Points)
            .HasColumnType("decimal")
            .HasPrecision(18,2)
            .IsRequired();

        builder.Property(p => p.TimeMinutes)
            .IsRequired();

        builder.HasOne<Course>(t => t.Course)
            .WithMany(c => c.Tests)
            .HasForeignKey(t => t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>(t => t.Creator)
            .WithMany(u => u.Tests)
            .HasForeignKey(t => t.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
