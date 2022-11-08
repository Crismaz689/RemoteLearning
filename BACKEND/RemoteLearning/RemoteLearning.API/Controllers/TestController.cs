using Microsoft.AspNetCore.Mvc;
using RemoteLearning.Infrastructure.Services;

namespace RemoteLearning.API.Controllers;

[Route("test")]
public class TestController : Controller
{
    private readonly IUserService _userService;
    //private readonly ILogger<TestController> _logger;

    public TestController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("halo")]
    public async Task<IActionResult> UserCreationTest()
    {
        await _userService.CreateUser("Dsad", "dasdsa");
        return Ok(true);
    }
}
