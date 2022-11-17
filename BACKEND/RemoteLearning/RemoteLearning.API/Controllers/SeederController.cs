namespace RemoteLearning.API.Controllers;

[Route("seeders")]
public class SeederController : BaseApiController
{
    [HttpGet("seed")]
    public ActionResult<bool> Seed()
    {

        return Ok(true);
    }
}
