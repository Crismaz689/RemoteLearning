namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
{
    public void Configure(EntityTypeBuilder<UserDetails> builder)
    {
        builder.ToTable("UsersDetails");

        builder.Property(p => p.FirstName)
            .IsRequired();

        builder.Property(p => p.Surname)
            .IsRequired();

        builder.Property(p => p.Pesel)
            .IsRequired();

        builder.Property(p => p.BirthdayDate)
            .IsRequired();

        builder.HasOne<User>(ud => ud.User)
            .WithOne(u => u.UserDetails)
            .HasForeignKey<UserDetails>(ud => ud.UserId);
    }
}
