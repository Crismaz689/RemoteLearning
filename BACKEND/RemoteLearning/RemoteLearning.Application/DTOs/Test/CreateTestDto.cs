namespace RemoteLearning.Application.DTOs.Test;

public class CreateTestDto
{
    public string Name { get; set; }

    public decimal Points { get; set; } = 0;

    public int TimeMinutes { get; set; } = 0;

    public int CourseId { get; set; }

    public int CreatorId { get; set; }
}
