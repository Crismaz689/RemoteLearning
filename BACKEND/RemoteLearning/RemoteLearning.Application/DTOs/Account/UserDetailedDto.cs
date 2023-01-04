namespace RemoteLearning.Application.DTOs.Account;

public class UserDetailedDto
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string Pesel { get; set; }

    public string Email { get; set; }

    public long RoleId { get; set; }
}
