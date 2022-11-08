namespace RemoteLearning.Domain.Entities;

public class CourseSection : BaseEntity
{
    public Course Course { get; set; }

    public long CourseId { get; set; }

    public Section Section { get; set; }
    
    public long SectionId { get; set; }

}
