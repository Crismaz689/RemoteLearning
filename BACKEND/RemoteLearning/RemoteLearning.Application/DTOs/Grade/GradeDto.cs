namespace RemoteLearning.Application.DTOs.Grade;

public class GradeDto
{
    public long Id { get; set; }

    public decimal Value { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string CategoryName { get; set; }
}
