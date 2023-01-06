namespace RemoteLearning.Application.DTOs.Test;

public class TestDto : CreateTestDto
{
    public long Id { get; set; }

    public decimal Points { get; set; }

    public int TimeMinutes { get; set; }

    public IEnumerable<TextQuestionDto> TextQuestions { get; set; }
}
