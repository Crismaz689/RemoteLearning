namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}
