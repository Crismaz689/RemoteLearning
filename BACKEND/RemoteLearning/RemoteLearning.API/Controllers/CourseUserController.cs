namespace RemoteLearning.API.Controllers;

[Route("rl/course-assignments")]
[Authorize]
public class CourseUserController : BaseApiController
{
    private readonly ICourseUserService _courseUserService;
    public CourseUserController(ICourseUserService courseUserService) => (_courseUserService) = (courseUserService);

    [HttpPost]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<long>> Create(CreateCourseUserDto dto) => await _courseUserService.CreateAssignment(dto.courseId, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(long id) => await _courseUserService.DeleteAssignment(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

}
