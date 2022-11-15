namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class TextQuestionConfiguration : IEntityTypeConfiguration<TextQuestion>
{
    public void Configure(EntityTypeBuilder<TextQuestion> builder)
    {
        builder.ToTable("TextQuestions");

        builder.Property(p => p.Title)
            .IsRequired();

        builder.Property(p => p.CorrectAnswer)
            .IsRequired();

        builder.Property(p => p.WrongAnswerA)
            .IsRequired();

        builder.Property(p => p.WrongAnswerB)
            .IsRequired();

        builder.Property(p => p.WrongAnswerC)
            .IsRequired();

        builder.Property(p => p.Points)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.TimeMinutes)
            .HasDefaultValue(1)
            .IsRequired();
    }
}
