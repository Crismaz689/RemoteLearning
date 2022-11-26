namespace RemoteLearning.API.Controllers;

[Route("rl/fake-test")]
public class TestingController : BaseApiController
{
    private readonly ILogger _logger;
    public TestingController(ILogger<TestingController> logger) 
    {
        _logger = logger;
    }

    [HttpGet("AdminTest")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> AdminTest()
    {
        return Ok("admin");
    }

    [HttpGet("UserTest")]
    [Authorize(Roles = "User")]
    public ActionResult<string> UserTest()
    {
        return Ok("user");
    }

    [HttpGet("TeacherTest")]
    [Authorize(Roles = "Teacher")]
    public ActionResult<string> TeacherTest()
    {
        return Ok("teacher");
    }

    [HttpGet("Unathorized")]
    public ActionResult<string> Unathorized()
    {
        _logger.LogInformation("test");
        _logger.LogError("tesctik2");
        return Ok("unathorized");
    }

    [HttpGet("NoRole")]
    [Authorize]
    public ActionResult<string> NoRole()
    {
        return Ok("no-role");
    }
}
