namespace RemoteLearning.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Grade> Grades { get; set; }
}
