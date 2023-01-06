namespace RemoteLearning.API.Controllers;

[Route("rl/categories")]
[Authorize(Roles = "Admin, Tutor")]
public class CategoryController : BaseApiController
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService) => (_categoryService) = (categoryService);

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll() => Ok(await _categoryService.GetAllCategories());
}
