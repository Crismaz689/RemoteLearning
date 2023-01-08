namespace RemoteLearning.Application.DTOs.Course;

public class CourseAllDataDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long CreatorId { get; set; }

    public IEnumerable<SectionDto> Sections { get; set; }

    public IEnumerable<TestDto> Tests { get; set; }

    public IEnumerable<GradeDto> Grades { get; set; }
}
