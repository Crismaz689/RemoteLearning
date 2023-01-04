namespace RemoteLearning.Application.DTOs.Section;

public class CreateSectionDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public long CourseId { get; set; }
}
