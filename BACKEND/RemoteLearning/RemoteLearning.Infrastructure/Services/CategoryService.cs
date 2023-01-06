namespace RemoteLearning.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var categories = await _unitOfWork.Categories.GetAll();

        return categories.Any() ?
            _mapper.Map<IEnumerable<CategoryDto>>(categories) : 
            Enumerable.Empty<CategoryDto>();
    }
}
