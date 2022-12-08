namespace RemoteLearning.Application.DTOs.Section;

public class UpdateSectionDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime ScheduleDate { get; set; }
}
