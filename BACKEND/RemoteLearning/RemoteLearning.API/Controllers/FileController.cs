namespace RemoteLearning.API.Controllers;

[Route("rl/files")]
[Authorize]
public class FileController : BaseApiController
{
    private readonly IFileService _fileService;
    public FileController(IFileService fileService) => (_fileService) = (fileService);

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FileDownloadDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<FileDownloadDto>> Create(long id) => await _fileService.DownloadFile(id);

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> Create([FromForm] FileCreateDto fileDto) => await _fileService.UploadFile(fileDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _fileService.DeleteFile(id);
}
