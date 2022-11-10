namespace RemoteLearning.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; private set; }

    private readonly RemoteLearningDbContext _context;
    //private readonly ILogger _logger;

    public UnitOfWork(RemoteLearningDbContext context)
    {
        _context = context;
        //_logger = logger.CreateLogger("logs");

        Users = new UserRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
