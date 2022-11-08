namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
    {
        builder.ToTable("Files");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Size)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(p => p.Type)
            .IsRequired();
    }
}
