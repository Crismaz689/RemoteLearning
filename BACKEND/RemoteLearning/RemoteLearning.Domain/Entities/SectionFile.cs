namespace RemoteLearning.Domain.Entities;

public class SectionFile : BaseEntity
{
    public File File { get; set; }

    public long FileId { get; set; }

    public Section Section { get; set; }

    public long SectionId { get; set; }
}
