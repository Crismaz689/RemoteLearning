namespace RemoteLearning.API.Controllers;

[Route("rl/text-questions")]
[Authorize]
public class TextQuestionController : BaseApiController
{
    private readonly ITextQuestionService _textQuestionService;
    public TextQuestionController(ITextQuestionService textQuestionService) => (_textQuestionService) = (textQuestionService);

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Get(long id) => Ok(await _textQuestionService.GetQuestionById(id));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => Ok(await _textQuestionService.DeleteQuestion(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpPost]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Create(CreateTextQuestionDto textQuestionDto) => Ok(await _textQuestionService.CreateQuestion(textQuestionDto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Tutor")]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Update(CreateTextQuestionDto textQuestionDto, long id) => Ok(await _textQuestionService.UpdateQuestion(textQuestionDto, id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value!));
}
