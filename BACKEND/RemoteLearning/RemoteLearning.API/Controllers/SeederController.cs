namespace RemoteLearning.API.Controllers;

[Route("seeders")]
//[Authorize(Roles = "Admin")]
public class SeederController : BaseApiController
{
    private readonly ISeederService _seederService;

    public SeederController(ISeederService seederService)
    {
        _seederService = seederService;
    }

    [HttpPost("seed-roles")]
    public async Task<ActionResult<bool>> SeedRoles() => await _seederService.SeedRoles();

    [HttpPost("seed-accounts")]
    public async Task<ActionResult<bool>> SeedAccounts() => await _seederService.SeedAccounts();
}
