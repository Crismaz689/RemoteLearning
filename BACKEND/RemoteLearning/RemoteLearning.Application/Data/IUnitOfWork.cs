namespace RemoteLearning.Application.Data;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    Task<int> CompletedAsync();
}
