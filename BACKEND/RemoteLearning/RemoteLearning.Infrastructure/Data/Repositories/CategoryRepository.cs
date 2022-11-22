namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(RemoteLearningDbContext context) : base(context) { }
}
