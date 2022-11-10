namespace RemoteLearning.Infrastructure.EntityConfigurations;

public class TestTextQuestionConfiguration : IEntityTypeConfiguration<TestTextQuestion>
{
    public void Configure(EntityTypeBuilder<TestTextQuestion> builder)
    {
        builder.ToTable("TestTextQuestions");

        builder.Property(p => p.TextQuestionId)
            .IsRequired();

        builder.Property(p => p.TestId)
            .IsRequired();

        builder.HasOne<Test>(tt => tt.Test)
            .WithMany(t => t.TestTextQuestions)
            .HasForeignKey(tt => tt.TestId);

        builder.HasOne<TextQuestion>(tt => tt.TextQuestion)
            .WithMany(t => t.TestTextQuestions)
            .HasForeignKey(tt => tt.TextQuestionId);

        builder.HasIndex(t => new { t.TextQuestionId, t.TestId });
    }
}
