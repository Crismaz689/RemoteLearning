namespace RemoteLearning.API.Controllers;

[Route("rl/accounts")]
[AllowAnonymous]
public class AccountController : BaseApiController
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService) => (_userService) = (userService);

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(IEnumerable<UserDetailedDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UserDetailedDto>>> GetAll() => Ok(await _userService.GetAllUsers());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Create(IEnumerable<CreateAccountDto> accountDtos) => Ok(await _userService.CreateUsers(accountDtos));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => Ok(await _userService.DeleteUser(id));

    [HttpPost("login")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) => Ok(await _userService.Login(loginDto));
}