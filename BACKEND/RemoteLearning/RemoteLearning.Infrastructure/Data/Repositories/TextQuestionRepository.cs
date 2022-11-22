namespace RemoteLearning.Infrastructure.Data.Repositories;

public class TextQuestionRepository : BaseRepository<TextQuestion>, ITextQuestionRepository
{
    public TextQuestionRepository(RemoteLearningDbContext context) : base(context) { }
}
