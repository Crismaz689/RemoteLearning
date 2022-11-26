namespace RemoteLearning.API.Controllers;

[Route("rl/sections")]
public class SectionController : BaseApiController
{
    private readonly ISectionService _sectionService;
    public SectionController(ISectionService sectionService) => (_sectionService) = (sectionService);

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SectionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SectionDto>> Get(long id) => await _sectionService.GetSectionById(id);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _sectionService.DeleteSection(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPost]
    [ProducesResponseType(typeof(SectionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SectionDto>> Create(CreateSectionDto sectionDto) => await _sectionService.CreateSection(sectionDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpPut]
    [ProducesResponseType(typeof(SectionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SectionDto>> Update(UpdateSectionDto sectionDto) => await _sectionService.UpdateSection(sectionDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}
