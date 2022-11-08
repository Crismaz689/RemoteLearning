namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class TestTextQuestionConfiguration : IEntityTypeConfiguration<TestTextQuestion>
{
    public void Configure(EntityTypeBuilder<TestTextQuestion> builder)
    {
        builder.ToTable("TestTextQuestions");

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
            .HasPrecision(2)
            .IsRequired();

        builder.Property(p => p.Time)
            .IsRequired();
    }
}
