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
            .HasPrecision(2)
            .IsRequired();

        builder.Property(p => p.Time)
            .IsRequired();
    }
}
