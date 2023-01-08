namespace RemoteLearning.Application.DTOs.Test;

public class TestForStudentDto
{
    public long Id { get; set; }

    public long TimeMinutes { get; set; }

    public IEnumerable<TextQuestionForStudentDto> TextQuestions { get; set; }
}
