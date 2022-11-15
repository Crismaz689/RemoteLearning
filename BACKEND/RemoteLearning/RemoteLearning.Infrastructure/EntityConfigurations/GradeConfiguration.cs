namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");

        builder.Property(p => p.Value)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.Title)
            .IsRequired();

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.Property(p => p.CategoryId)
            .IsRequired();

        builder.HasOne<User>(g => g.User)
            .WithMany(u => u.Grades)
            .HasForeignKey(g => g.UserId);

        builder.HasOne<Test>(g => g.Test)
            .WithOne(t => t.Grade)
            .HasForeignKey<Grade>(g => g.TestId);
    }
}