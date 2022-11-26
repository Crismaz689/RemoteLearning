namespace RemoteLearning.API.Controllers;

[Route("rl/seeders")]
//[Authorize(Roles = "Admin")]
public class SeederController : BaseApiController
{
    private readonly ISeederService _seederService;

    public SeederController(ISeederService seederService)
    {
        _seederService = seederService;
    }

    [HttpPost("seed-roles")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SeedRoles() => await _seederService.SeedRoles();

    [HttpPost("seed-accounts")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SeedAccounts() => await _seederService.SeedAccounts();
}
