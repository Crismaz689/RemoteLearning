namespace RemoteLearning.Application.Data;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    IUserDetailsRepository UsersDetails { get; }

    Task<int> SaveChangesAsync();
}
