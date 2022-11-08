namespace RemoteLearning.Domain.Entities;

public class Section : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime ScheduleDate { get; set; }

    public ICollection<CourseSection> CourseSections { get; set; }

    public ICollection<SectionFile> SectionFiles { get; set; }
}
