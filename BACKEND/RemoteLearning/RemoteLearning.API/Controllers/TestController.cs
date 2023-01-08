namespace RemoteLearning.API.Controllers;

[Route("rl/tests")]
[Authorize]
public class TestController : BaseApiController
{
    private readonly ITestService _testService;
    public TestController(ITestService testService) => (_testService) = (testService);

    [HttpGet("admin-get-all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(IEnumerable<TestAdminDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TestAdminDto>>> GetAllTestsAdmin() => Ok(await _testService.GetAllTestsByAdmin());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Get(long id) => await _testService.GetTestById(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpGet("take-test/{id}")]
    [ProducesResponseType(typeof(TestForStudentDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestForStudentDto>> GetTestByStudent(long id) => await _testService.GetTestByStudent(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpGet("was-taken/{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> GetTestStatus(long id) => await _testService.WasTestTaken(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _testService.DeleteTest(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Create(CreateTestDto testDto) => await _testService.CreateTest(testDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost("confirm")]
    [Authorize(Roles = "User, Admin")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> ConfirmTest(TestFinishedDto dto) => await _testService.ConfirmTest(dto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Update(CreateTestDto testDto, long id) => await _testService.UpdateTest(testDto, id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}
