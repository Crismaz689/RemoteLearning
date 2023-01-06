namespace RemoteLearning.API.Controllers;

[Route("rl/courses")]
[Authorize]
public class CourseController : BaseApiController
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService) => (_courseService) = (courseService);

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CourseAllDataDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseAllDataDto>> Get(long id) => await _courseService.GetCourseById(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpGet("my-courses")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetMyCourses() => Ok(await _courseService.GetMyCourses(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpGet("admin-get-all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesAdmin() => Ok(await _courseService.GetAllCoursesAdmin());

    [HttpGet("assigned-courses")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAssignedCourses() => Ok(await _courseService.GetAssignedCourses(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses() => Ok(await _courseService.GetAllCourses(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _courseService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(CourseDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> Create(CreateCourseDto courseDto) => await _courseService.Create(courseDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(CourseDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> Update(UpdateCourseDto courseDto, long id) => await _courseService.Update(courseDto, id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}
