namespace RemoteLearning.API.Controllers;

[Route("rl/accounts")]
[AllowAnonymous]
public class AccountController : BaseApiController
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService) => (_userService) = (userService);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Create(IEnumerable<CreateAccountDto> accountDtos) => await _userService.CreateUsers(accountDtos);

    [HttpPost("login")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) => await _userService.Login(loginDto);
}