namespace RemoteLearning.Application.DTOs.Grade;

public class CreateGradeDto
{
    public decimal Value { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public long CourseId { get; set; }

    public long UserId { get; set; }

    public long CategoryId { get; set; }
}
