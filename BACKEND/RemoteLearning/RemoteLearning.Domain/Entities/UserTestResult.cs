namespace RemoteLearning.Domain.Entities;

public class UserTestResult : BaseEntity
{
    public long UserId { get; set; }

    public virtual User User { get; set; }

    public long TestId { get; set; }

    public virtual Test Test { get; set; }

    public decimal Points { get; set; }

    public decimal TotalPoints { get; set; }
}
