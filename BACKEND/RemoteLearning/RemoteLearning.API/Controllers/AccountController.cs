namespace RemoteLearning.API.Controllers;

[Route("accounts")]
public class AccountController : BaseApiController
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(CreateAccountDto accountDto) => await _userService.CreateUser(accountDto);

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginDto loginDto) => await _userService.Login(loginDto);
}