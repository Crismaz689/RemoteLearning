namespace RemoteLearning.API.Controllers;

[Route("rl/course-assignments")]
public class CourseUserController : BaseApiController
{
    private readonly ICourseUserService _courseUserService;
    public CourseUserController(ICourseUserService courseUserService)
    {
        _courseUserService = courseUserService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<long>> Create(CreateCourseUserDto courseUserDto) => await _courseUserService.Create(courseUserDto);

    /*
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(long id) => await _courseService.Delete(id);*/

}
