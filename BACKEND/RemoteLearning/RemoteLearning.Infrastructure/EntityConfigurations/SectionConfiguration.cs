namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasOne<Course>(s => s.Course)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.CourseId);
    }
}
