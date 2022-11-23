namespace RemoteLearning.Application.DTOs.Course;

public class UpdateCourseDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}
