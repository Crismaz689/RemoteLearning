namespace RemoteLearning.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

    public DateTime ModificationDate { get; set; } = DateTime.Now;
}
