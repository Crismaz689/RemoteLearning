namespace RemoteLearning.API.Controllers;

[Route("rl/tests")]
public class TestController : BaseApiController
{
    private readonly ITestService _testService;
    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Get(long id) => await _testService.GetTestById(id);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _testService.DeleteTest(id);

    [HttpPost]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Create(CreateTestDto testDto) => await _testService.CreateTest(testDto);

    [HttpPut]
    [ProducesResponseType(typeof(TestDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TestDto>> Update(CreateTestDto testDto) => await _testService.UpdateTest(testDto);
}
