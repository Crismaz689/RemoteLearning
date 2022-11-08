namespace RemoteLearning.Domain.Entities;

public class UserDetails : BaseEntity
{
    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string Pesel { get; set; }

    public DateTime BirthdayDate { get; set; }
}