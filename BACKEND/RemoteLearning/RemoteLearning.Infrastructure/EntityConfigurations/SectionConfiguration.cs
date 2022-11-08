namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");

        builder.Property(p => p.Name)
            .IsRequired();
    }
}
