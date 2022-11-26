namespace RemoteLearning.API.Controllers;

[Route("rl/courses")]
public class CourseController : BaseApiController
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CourseDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> Get(long id) => await _courseService.GetCourseById(id);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _courseService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost]
    [ProducesResponseType(typeof(CourseDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> Create(CreateCourseDto courseDto) => await _courseService.Create(courseDto);

    [HttpPut]
    [ProducesResponseType(typeof(CourseDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> Update(UpdateCourseDto courseDto) => await _courseService.Update(courseDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}
