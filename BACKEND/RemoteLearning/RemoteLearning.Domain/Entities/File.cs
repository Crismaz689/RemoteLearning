namespace RemoteLearning.Domain.Entities;

public class File : BaseEntity
{
    public string Name { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }

    public virtual Section Section { get; set; }

    public long SectionId { get; set; }
}
