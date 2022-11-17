namespace RemoteLearning.API.Controllers;

[Route("tests")]
public class TestController : BaseApiController
{
    private readonly IUserService _userService;

    public TestController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("UserCreation")]
    public ActionResult<bool> UserCreationTest()
    {

        return Ok(true);
    }
}
