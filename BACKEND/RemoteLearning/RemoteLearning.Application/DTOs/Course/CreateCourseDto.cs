namespace RemoteLearning.Application.DTOs.Course;

public class CreateCourseDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long CreatorId { get; set; }
}
