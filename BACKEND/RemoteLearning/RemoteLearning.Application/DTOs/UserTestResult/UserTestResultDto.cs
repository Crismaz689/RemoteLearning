namespace RemoteLearning.Application.DTOs.UserTestResult;

public class UserTestResultDto
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public decimal Points { get; set; }

    public decimal TotalPoints { get; set; }

    public DateTime FinishDate { get; set; }
}
