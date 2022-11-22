namespace RemoteLearning.API.Controllers;

[Route("courses")]
public class CourseController : BaseApiController
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> Get(long id) => await _courseService.GetCourseById(id);

    /*[HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(long id) => await _courseRepository.Delete(id);

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(CreateCourseDto courseDto) => await _courseRepository.Create(courseDto);

    [HttpPut()]
    public async Task<ActionResult<CourseDto>> Update(long id, CreateCourseDto courseDto) => await _courseRepository.Update(id, courseDto); */
}
