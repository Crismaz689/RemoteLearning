namespace RemoteLearning.Domain.Entities;

public class Grade : BaseEntity
{
    public decimal Value { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public virtual Test? Test { get; set; }

    public long? TestId { get; set; }

    public virtual User User { get; set; }

    public long UserId { get; set; }

    public virtual Category Category { get; set; }

    public long CategoryId { get; set; }
}
