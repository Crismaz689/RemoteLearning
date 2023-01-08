
namespace RemoteLearning.API.Controllers;

[Route("rl/grades")]
[Authorize]
public class GradeContoller : BaseApiController
{
    private readonly IGradeService _gradeService;
    public GradeContoller(IGradeService gradeService) => (_gradeService) = (gradeService);

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(GradeDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GradeDto>> Create(CreateGradeDto gradeDto) => Ok(await _gradeService.CreateGrade(gradeDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GradeUserDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GradeUserDto>>> GetUserGrades() => Ok(await _gradeService.GetUserGrades(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpGet("admin-get-all")]
    [ProducesResponseType(typeof(IEnumerable<GradeUserDetailedDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GradeUserDetailedDto>>> GetAllUsersGrades() => Ok(await _gradeService.GetAllUsersGrades());

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => Ok(await _gradeService.DeleteGrade(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(GradeDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GradeDto>> Update(CreateGradeDto gradeDto, long id) => Ok(await _gradeService.UpdateGrade(gradeDto, id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));
}
