namespace RemoteLearning.Domain.Entities;

public class File : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Size { get; set; }

    public string Extension { get; set; }

    public string MimeType { get; set; }

    public string Path { get; set; }

    public virtual Section Section { get; set; }

    public long SectionId { get; set; }
}
