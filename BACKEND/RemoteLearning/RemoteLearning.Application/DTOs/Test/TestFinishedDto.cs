namespace RemoteLearning.Application.DTOs.Test;

public class TestFinishedDto
{
    public long TestId { get; set; }

    public IEnumerable<TextQuestionAnswerDto> Answers { get; set; }
}
