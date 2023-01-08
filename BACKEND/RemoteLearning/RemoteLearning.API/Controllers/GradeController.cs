
namespace RemoteLearning.API.Controllers;

[Route("rl/grades")]
[Authorize(Roles = "Admin, Tutor")]
public class GradeContoller : BaseApiController
{
    private readonly IGradeService _gradeService;
    public GradeContoller(IGradeService gradeService) => (_gradeService) = (gradeService);

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(GradeDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GradeDto>> Create(CreateGradeDto gradeDto) => await _gradeService.CreateGrade(gradeDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}
