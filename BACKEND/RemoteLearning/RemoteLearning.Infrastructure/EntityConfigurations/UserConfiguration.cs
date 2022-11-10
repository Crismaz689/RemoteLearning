namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasIndex(p => p.Username)
            .IsUnique();

        builder.HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
    }
}
