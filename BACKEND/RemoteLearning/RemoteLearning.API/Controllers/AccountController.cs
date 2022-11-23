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
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Create(IEnumerable<CreateAccountDto> accountDtos) => await _userService.CreateUsers(accountDtos);

    [HttpPost("login")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> Login(LoginDto loginDto) => await _userService.Login(loginDto);
}