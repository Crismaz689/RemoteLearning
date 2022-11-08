namespace RemoteLearning.Domain.Entities;

public class File : BaseEntity
{
    public string Name { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }

    public ICollection<SectionFile> SectionFiles { get; set; }
}
