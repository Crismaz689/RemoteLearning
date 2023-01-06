namespace RemoteLearning.API.Controllers;

[Route("rl/seeders")]
//[Authorize(Roles = "Admin")]
public class SeederController : BaseApiController
{
    private readonly ISeederService _seederService;
    private readonly IApplicationBuilder _builder;

    public SeederController(ISeederService seederService, IApplicationBuilder builder) => (_seederService, _builder) = (seederService, builder);

    [HttpPost("seed-roles")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SeedRoles() => Ok(await _seederService.SeedRoles());

    [HttpPost("seed-accounts")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SeedAccounts() => Ok(await _seederService.SeedAccounts());

    [HttpPost("seed-categories")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SeedCategories() => Ok(await _seederService.SeedCategories());

    [HttpPost("create-triggers")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public ActionResult CreateTriggers()
    {
        _seederService.CreateTriggers(_builder);

        return Ok();
    }
}
