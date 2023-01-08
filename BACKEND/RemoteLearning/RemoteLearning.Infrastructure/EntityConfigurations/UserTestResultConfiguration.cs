namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class UserTestResultConfiguration : IEntityTypeConfiguration<UserTestResult>
{
    public void Configure(EntityTypeBuilder<UserTestResult> builder)
    {
        builder.ToTable("UsersTestsResults");

        builder.Property(p => p.TestId)
            .IsRequired();

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.Property(p => p.Points)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.TotalPoints)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasOne<Test>(p => p.Test)
            .WithMany(t => t.UserTestResults)
            .HasForeignKey(p => p.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>(p => p.User)
            .WithMany(u => u.UserTestResults)
            .HasForeignKey(p => p.UserId);

        builder.HasIndex(c => new { c.TestId, c.UserId })
            .IsUnique();
    }
}
