namespace RemoteLearning.Application.Data.Repositories;

public interface IUserDetailsRepository : IBaseRepository<UserDetails>
{
    Task<UserDetails> GetUserByEmail(string email);

    Task<UserDetails> GetUserByPesel(string pesel);
}
