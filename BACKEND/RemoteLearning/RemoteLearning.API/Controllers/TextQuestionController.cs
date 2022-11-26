namespace RemoteLearning.API.Controllers;

[Route("rl/text-questions")]
public class TextQuestionController : BaseApiController
{
    private readonly ITextQuestionService _textQuestionService;
    public TextQuestionController(ITextQuestionService textQuestionService)
    {
        _textQuestionService = textQuestionService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Get(long id) => await _textQuestionService.GetQuestionById(id);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> Delete(long id) => await _textQuestionService.DeleteQuestion(id);

    [HttpPost]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Create(CreateTextQuestionDto textQuestionDto) => await _textQuestionService.CreateQuestion(textQuestionDto);

    [HttpPut]
    [ProducesResponseType(typeof(TextQuestionDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<TextQuestionDto>> Update(CreateTextQuestionDto textQuestionDto) => await _textQuestionService.UpdateQuestion(textQuestionDto);
}
