namespace RemoteLearning.Domain.Entities;

public class TestTextQuestion : BaseEntity
{
    public Test Test { get; set; }

    public long TestId { get; set; }

    public TextQuestion TextQuestion { get; set; }

    public long TextQuestionId { get; set; }

}