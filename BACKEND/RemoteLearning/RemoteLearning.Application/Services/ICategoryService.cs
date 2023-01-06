namespace RemoteLearning.Application.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategories();
}
