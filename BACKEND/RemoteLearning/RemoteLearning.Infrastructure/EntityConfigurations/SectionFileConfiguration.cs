namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class SectionFileConfiguration : IEntityTypeConfiguration<SectionFile>
{
    public void Configure(EntityTypeBuilder<SectionFile> builder)
    {
        builder.ToTable("SectionFiles");

        builder.Property(p => p.FileId)
            .IsRequired();

        builder.Property(p => p.SectionId)
            .IsRequired();

        builder.HasOne<Section>(sf => sf.Section)
            .WithMany(s => s.SectionFiles)
            .HasForeignKey(sf => sf.SectionId);

        builder.HasOne<Domain.Entities.File>(sf => sf.File)
            .WithMany(f => f.SectionFiles)
            .HasForeignKey(sf => sf.FileId);

        builder.HasIndex(sf => new { sf.SectionId, sf.FileId });
    }
}