namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class CourseSectionConfiguration : IEntityTypeConfiguration<CourseSection>
{
    public void Configure(EntityTypeBuilder<CourseSection> builder)
    {
        builder.ToTable("CourseSections");

        builder.Property(p => p.CourseId)
            .IsRequired();

        builder.Property(p => p.SectionId)
            .IsRequired();

        builder.HasOne<Course>(c => c.Course)
            .WithMany(cs => cs.CourseSections)
            .HasForeignKey(c => c.CourseId);

        builder.HasOne<Section>(c => c.Section)
            .WithMany(s => s.CourseSections)
            .HasForeignKey(c => c.SectionId);

        builder.HasIndex(c => new { c.CourseId, c.SectionId })
            .IsUnique();
    }
}
